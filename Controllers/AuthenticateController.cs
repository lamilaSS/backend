using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using mcq_backend.Helper;
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
        private readonly JWTFactory _factory;

        public AuthenticateController(JWTFactory factory)
        {
            _factory = factory;
        }

        // GET
        [HttpPost]
        public ActionResult Login(LoginDAL dataset)
        {
            var (username, password) = dataset;
            if (username is not Usrname || password is not Psswrd) return Forbid();
            
            var toke = _factory.CreateToken(username);
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(toke)
            });
        }
    }

    public record LoginDAL(string Username, string Password);
}