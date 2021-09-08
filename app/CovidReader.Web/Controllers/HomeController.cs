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
    public class HomeController : ControllerBase
    {
        public HomeController()
        {
            
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello React!!!!"); //HTTPステータスコード200を返す
        }
    }
}
