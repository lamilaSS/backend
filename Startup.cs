using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using mcq_backend.Helper;
using mcq_backend.Helper.AppHelper;
using mcq_backend.Helper.Cache;
using mcq_backend.Helper.Context;
using mcq_backend.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace mcq_backend
{
    public class Startup
    {
        public readonly IConfiguration Configuration;
        // private const string ServicePath = "./service-account.json";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            // FirebaseApp.Create(new AppOptions()
            // {
            //     // Credential = GoogleCredential.FromFile(ServicePath)
            // });
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var appSettingsOptions = new AppSettingsOptions();
            Configuration.GetSection(AppSettingsOptions.AppSettings).Bind(appSettingsOptions);
            
            //DI Configuration appsettings for later use
            services.AddSingleton<AppSettingsOptions>(appSettingsOptions);
            //DI JWT Factory use for creating 
            services.AddScoped<JWTFactory>();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MCQ API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the bearer scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header,  
                    Type = SecuritySchemeType.ApiKey
                });
                
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                        new List<string>()
                    }
                });
            });
            
            // Cors configure
            services.AddCors(opts =>
            {
                opts.AddPolicy("AllowAll", builder =>
                {
                    builder
                        // .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                });
            });
            
            // Add jwt authentication
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    
                    cfg.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettingsOptions.JwtSecret)),
                        ValidateIssuer = true,
                        ValidIssuer = appSettingsOptions.Issuer,
                        ValidateAudience = true,
                        ValidAudience = appSettingsOptions.Audience,
                        RequireExpirationTime = false
                    };
                });
            
            
            // DB configure
            services.AddDbContext<DBContext>(opts =>
                opts
                    .UseNpgsql(Configuration["ConnectionString:McqDB"])
                    .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
            );
            services.AddScoped<DBContext>();
            
            // Add unit of work scope
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            // set up redis cache
            var redisCacheSettings = new RedisSettingsOptions();
            Configuration.GetSection(RedisSettingsOptions.RedisSettings).Bind(redisCacheSettings);
            services.AddSingleton(redisCacheSettings);
            if (redisCacheSettings.Enabled)
            {
                services.AddStackExchangeRedisCache(options =>
                    options.Configuration = redisCacheSettings.ConnectionString);
                services.AddSingleton<CacheHelper>();
            }
            
            // Configure controller
            services.AddControllers().AddNewtonsoftJson(opt =>
                opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            
            // Auto mapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            // get config object
            AppConfig.SetConfig(Configuration);
            // Add services
            AddServicesScoped(services);
            
            // create singleton context accessor
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ClaimProvider>();
            
            // API versioning
            services.AddApiVersioning(x =>
            {
                x.DefaultApiVersion = new ApiVersion(1, 0);
                x.AssumeDefaultVersionWhenUnspecified = true;
                x.ReportApiVersions = true;
            });
            
            ////  in case of SignalR
            // services.AddSignalR();
            // services.AddSingleton<IHubConnectionManager, HubConnectionManager>();
            // services.AddSingleton<IHubNotificationHelper, HubNotificationHelper>();
        }

        private void AddServicesScoped(IServiceCollection services)
        {
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("AllowAll");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MCQ API v1"));
                
                var rewrite = new RewriteOptions().AddRedirect("^$", "swagger");
                app.UseRewriter(rewrite);
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                
                // in case of SignalR
                // endpoints.MapHub<SignalR>("/notifications");
            });
        }
    }
}
