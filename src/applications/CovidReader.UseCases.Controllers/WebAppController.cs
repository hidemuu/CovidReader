using CovidReader.Service;
using CovidReader.Service.Api;
using CovidReader.Service.Covid19;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.UseCases.Controllers
{
    /// <summary>
    /// Webアプリケーション用コントローラー
    /// </summary>
    public class WebAppController : AppControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="api"></param>
        /// <param name="covid19"></param>
        public WebAppController(IApiService api, ICovid19Service covid19) : base(api, covid19)
        {
           
        }
        
    }
}
