using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using mcq_backend.Helper.AppHelper;
using Microsoft.IdentityModel.Tokens;

namespace mcq_backend.Helper
{
    public class JWTFactory
    {
        private readonly AppSettingsOptions _appSettings;
        public JWTFactory(AppSettingsOptions appSettings)
        {
            _appSettings = appSettings;
        }
        public SecurityToken CreateToken(string username)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, "1"),
                new Claim(JwtRegisteredClaimNames.Email, username),
                new Claim(ClaimTypes.Role, "user"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appSettings.JwtSecret));
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

            return toke;
        }
    }
}