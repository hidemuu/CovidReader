using CovidReader.Service;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Controllers
{
    /// <summary>
    /// Webアプリケーション用コントローラー
    /// </summary>
    public class WebAppController : AppController
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
