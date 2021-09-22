using CovidReader.Service;
using CovidReader.Service.Api;
using CovidReader.Service.Covid19;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Controllers
{
    /// <summary>
    /// ネイティブアプリケーション用コントローラー
    /// </summary>
    public class NativeAppController : AppController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="api"></param>
        /// <param name="covid19"></param>
        public NativeAppController(IApiService api, ICovid19Service covid19) : base(api, covid19)
        {
            
        }

    }
}
