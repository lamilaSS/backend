using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using mcq_backend.Helper.Context;
using mcq_backend.Model;
using mcq_backend.Model.Keyless;
using mcq_backend.Repository;
using Microsoft.EntityFrameworkCore;

namespace mcq_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly DBContext _ctx;
        private IMapper _mapper;
        private IGenericRepository<IdoruKeyless> _idorukl;
        private IGenericRepository<Idoru> _idoru;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, DBContext ctx, IMapper mapper)
        {
            _logger = logger;
            _ctx = ctx;
            _mapper = mapper;
            _idorukl = new GenericRepository<IdoruKeyless>(_ctx);
            _idoru = new GenericRepository<Idoru>(_ctx);
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
        public async Task<IList<IdoruParam>> GetIdol()
        {
            var result = await _idoru.Get();
            return _mapper.Map<IList<IdoruParam>>(result);
        }

        [HttpGet("keyless-idol")]
        public IList<IdoruKeyless> GetIdolKeyless()
        {
            var result = _idorukl.RawSelect($"select * from getIdol(1,4)");
            return result;
        }

        [HttpPost("add-idol")]
        public async Task<ActionResult<Idoru>> SetIdol(IdoruParam idoru)
        {
            var newIdol = new Idoru()
            {
                Name = idoru.Name,
                Age = idoru.Age,
                Addr = idoru.Addr,
                Gender = idoru.Gender
            };
            var res = await _ctx.Idoru.AddAsync(newIdol);
            if (await _ctx.SaveChangesAsync() < 0)
            {
                return BadRequest();
            }

            return Ok(await _ctx.Idoru.FindAsync(newIdol.Id));
        }

        [HttpPut("update-idol")]
        public async Task<ActionResult<Idoru>> UpdateIdol(int id, IdoruParam idoru)
        {
            var curr = await _ctx.Idoru.FindAsync(id);
            curr.Addr = idoru.Addr;
            curr.Name = idoru.Name;
            curr.Age = idoru.Age;
            curr.Gender = idoru.Gender;

            _ctx.Attach(curr);
            _ctx.Update(curr);

            if (await _ctx.SaveChangesAsync() < 0)
            {
                return BadRequest();
            }

            return Ok(await _ctx.Idoru.FindAsync(curr.Id));
        }
    }

    public record IdoruParam(string Name, short Age, string Addr, bool Gender);
}