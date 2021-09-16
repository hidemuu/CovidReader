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
    public class InspectionController : ControllerBase
    {
        private readonly IInspectionRepository _repository;

        public InspectionController(IInspectionRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Gets all items.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok((await _repository.GetAsync()).OrderBy(x => DateTime.Parse(x.Date)));
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

        [HttpGet("calc/{calc}")]
        public async Task<IActionResult> GetByCalc(string calc)
        {
            if (calc == string.Empty)
            {
                return BadRequest();
            }
            var result = await _repository.GetAsync();
            if (result == null)
            {
                return NotFound();
            }
            var query = result.Where(x => x.Calc == calc);
            return Ok(query);
        }

        /// <summary>
        /// Creates a new item or updates an existing one.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Inspection item)
        {
            await _repository.PostAsync(item);
            return Ok();
        }

        /// <summary>
        /// Deletes an order.
        /// </summary>
        [HttpDelete("{date}")]
        public async Task<IActionResult> Delete(Inspection item)
        {
            await _repository.DeleteAsync(item.Date);
            return Ok();
        }
    }
}
