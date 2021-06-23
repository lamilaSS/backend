using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using mcq_backend.Dataset.Game;
using mcq_backend.Service.Game;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mcq_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [Authorize(Roles = "user")]
        [HttpGet]
        public async Task<ActionResult<AiLaTyPhuGameDataset>> createALTPSession()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return await _gameService.CreateALTPGameSession(userId);
        }
    }
}