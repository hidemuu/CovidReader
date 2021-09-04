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
    public class TestController : ControllerBase
    {
        // GET: api/<TestController>
        //[Authorize] この属性を付けると認証されたユーザーのみ実行可能とする
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello React!!!!"); //HTTPステータスコード200を返す
        }
    }
}
