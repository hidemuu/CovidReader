using CovidReader.Models.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidReader.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChartItemController : ControllerBase
    {
        
        private readonly ILogger<ChartItemController> _logger;

        public ChartItemController(ILogger<ChartItemController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<ChartItem> Get()
        {
            
            return Enumerable.Range(1, 5).Select(index => new ChartItem
            {
                Date = DateTime.Now.AddDays(index).ToShortDateString(),
                Data = ""
            })
            .ToArray();
        }
    }
}
