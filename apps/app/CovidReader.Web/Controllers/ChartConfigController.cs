using CovidReader.Models.Api;
using CovidReader.Repository.Api;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidReader.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartConfigController : ControllerBase
    {
        private readonly IChartConfigRepository _repository;

        public ChartConfigController(IChartConfigRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Gets all items.
        /// </summary>
        [HttpGet]
        public async Task<IEnumerable<ChartConfig>> Get()
        {
            //var task = Task.Run(() => _repository.GetAsync());
            //Task.WaitAll(task);
            //return Ok(task.Result);
            //return Ok(await _repository.GetAsync());
            return await _repository.GetAsync();
        }

        /// <summary>
        /// Creates a new item or updates an existing one.
        /// </summary>
        [HttpPost]
        public IActionResult Post([FromBody] IEnumerable<ChartConfig> item)
        {
            var task = Task.Run(() => _repository.PostAsync(item));
            Task.WaitAll(task);
            return Ok();
        }

        
    }
}
