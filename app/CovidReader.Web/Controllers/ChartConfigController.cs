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
        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.GetAsync());
        }

        /// <summary>
        /// Creates a new item or updates an existing one.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] IEnumerable<ChartConfig> item)
        {
            await _repository.PostAsync(item);
            return Ok();
        }

        
    }
}
