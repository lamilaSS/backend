using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mcq_backend.Helper.Context;
using mcq_backend.Model;
using Microsoft.EntityFrameworkCore;

namespace mcq_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly DBContext _ctx;
        
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, DBContext ctx)
        {
            _logger = logger;
            _ctx = ctx;

        }

        [HttpGet]
        public IEnumerable<WeathaForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeathaForecast(DateTime.Now.AddDays(index),
                    rng.Next(-20, 55),
                    Summaries[rng.Next(Summaries.Length)])
                )
                .ToArray();
        }

        [HttpGet("idol")]
        public async Task<IEnumerable<Idoru>> GetIdol()
        {
            var result = await _ctx.Idoru.ToListAsync();
            return result;
        }
    }
}