using CovidReader.Core;
using CovidReader.Core.Service;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Controllers
{
    public class WebController : ApiController
    {

        public WebController(IApiService api, ICovid19Service covid19) : base(api, covid19)
        {
           
        }
        
    }
}
