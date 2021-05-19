using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using mcq_backend.Helper.AppHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace mcq_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticateController : ControllerBase
    {
        private const string Usrname = "abcd";
        private const string Psswrd = "1234";
        private readonly AppSettingsOptions _appSettings;

        public AuthenticateController(AppSettingsOptions appSettings)
        {
            _appSettings = appSettings;
        }

        // GET
        [HttpPost]
        public ActionResult Login(LoginDAL dataset)
        {
            var (username, password) = dataset;
            if (username is Usrname && password is Psswrd)
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, "1"),
                    new Claim(JwtRegisteredClaimNames.Email, username),
                    new Claim(ClaimTypes.Role, "user"),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
                var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appSettings.JwtSecret));
                // var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                // var token = new JwtSecurityToken(AppSettings.Settings.Issuer,
                //     AppSettings.Settings.Audience,
                //     claims,
                //     // expires: DateTime.Now.AddSeconds(55 * 60),
                //     signingCredentials: creds);
                var jwtDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(claims),
                    SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature),
                    Audience = _appSettings.Audience,
                    Issuer = _appSettings.Issuer,
                    Expires = DateTime.Now.AddDays(2),
                };
                var toke = new JwtSecurityTokenHandler().CreateToken(jwtDescriptor);
                Console.WriteLine(toke);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(toke)
                });
            }
            else return Forbid();
        }
    }

    public record LoginDAL(string Username, string Password);
}