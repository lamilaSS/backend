using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using mcq_backend.Helper;
using mcq_backend.Helper.AppHelper;
using mcq_backend.Repository;
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
        private readonly IUnitOfWork _unitOfWork;

        public AuthenticateController(JWTFactory factory, IUnitOfWork unitOfWork)
        {
            _factory = factory;
            _unitOfWork = unitOfWork;
        }

        // GET
        [HttpPost]
        public async Task<ActionResult> Login(LoginDAL dataset)
        {
            var (username, password) = dataset;
            if (_unitOfWork.UserRepository.GetTotalCount() > 0)
            {
                if ((await _unitOfWork.UserRepository.Get(u =>
                    u.UserId.Equals(dataset.Username) && u.Password.Equals(dataset.Password))).Count <= 0)
                {
                    return Forbid();
                }
                
            }
            else if (username is not Usrname || password is not Psswrd) return Forbid();
            
            var toke = _factory.CreateToken(username);
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(toke)
            });
        }
    }

    public record LoginDAL(string Username, string Password);
}