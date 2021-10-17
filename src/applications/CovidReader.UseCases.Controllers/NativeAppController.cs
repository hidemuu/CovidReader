using CovidReader.Service;
using CovidReader.Service.Api;
using CovidReader.Service.Covid19;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.UseCases.Controllers
{
    /// <summary>
    /// ネイティブアプリケーション用コントローラー
    /// </summary>
    public class NativeAppController : AppControllerBase
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
