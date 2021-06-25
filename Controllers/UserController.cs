using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using mcq_backend.Dataset.User;
using mcq_backend.Service.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mcq_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<UserDataset>> GetUserById([FromQuery] string userId)
        {
            return await _userService.GetById(userId);
        }

        [HttpPatch]
        [Authorize(Roles = "user")]
        public async Task<ActionResult<UserDataset>> UpdateUser([FromBody] UserUpdateDataset updateDataset)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return await _userService.UpdateUser(userId, updateDataset);
        }
    }
}