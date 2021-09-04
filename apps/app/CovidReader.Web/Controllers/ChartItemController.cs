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
    public class ChartItemController : ControllerBase
    {
        private readonly IChartItemRepository _repository;

        public ChartItemController(IChartItemRepository repository)
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
        /// Gets the with the given date.
        /// </summary>
        [HttpGet("{date}")]
        public async Task<IActionResult> Get(string date)
        {
            if (date == string.Empty)
            {
                return BadRequest();
            }
            var result = await _repository.GetAsync(date);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        /// <summary>
        /// Creates a new item or updates an existing one.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ChartItem item)
        {
            await _repository.PostAsync(item);
            return Ok();
        }

        /// <summary>
        /// Deletes an order.
        /// </summary>
        [HttpDelete("{date}")]
        public async Task<IActionResult> Delete(ChartItem item)
        {
            await _repository.DeleteAsync(item.Date);
            return Ok();
        }

    }
}
