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
        public async Task<IEnumerable<ChartItem>> Get()
        {
            //var task = Task.Run(() => _repository.GetAsync());
            //Task.WaitAll(task);
            //return Ok(task.Result);
            //return Ok(await _repository.GetAsync());
            return await _repository.GetAsync();
        }

        /// <summary>
        /// Gets the with the given date.
        /// </summary>
        [HttpGet("{date}")]
        public IActionResult Get(string date)
        {
            if (date == string.Empty)
            {
                return BadRequest();
            }
            var task = Task.Run(() => _repository.GetAsync(date));
            Task.WaitAll(task);
            var result = task.Result;
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
        public IActionResult Post([FromBody] ChartItem item)
        {
            var task = Task.Run(() => _repository.PostAsync(item));
            Task.WaitAll(task);
            return Ok();
        }

        /// <summary>
        /// Deletes an order.
        /// </summary>
        [HttpDelete("{date}")]
        public IActionResult Delete(ChartItem item)
        {
            var task = Task.Run(() => _repository.DeleteAsync(item.Date));
            Task.WaitAll(task);
            return Ok();
        }

    }
}
