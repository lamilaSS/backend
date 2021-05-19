using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using mcq_backend.Helper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace mcq_backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var json = File.ReadAllText(@"appsettings.json");
            var o = JObject.Parse(@json);
            AppSettings.Settings = JsonConvert.DeserializeObject<AppSettings>(o["AppSettings"].ToString());
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseKestrel();
                });
    }
}
