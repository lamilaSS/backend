using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using mcq_backend.Dataset.Question;
using mcq_backend.Service.Question;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mcq_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //TODO: have proper roles
    [Authorize(Roles = "user")]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CreateQuestions([FromBody] List<QuestionCreate> newQuestions)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return await _questionService.CreateQuestions(newQuestions, userId);
        }

        [HttpGet]
        public async Task<List<QuestionDataset>> GetQuestions([FromQuery]List<Guid> questionIds)
        {
            return await _questionService.GetQuestions(questionIds);
        }
    }
}