using CovidReader.Core;
using CovidReader.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Controllers
{
    public class NativeController : ApiController
    {
        
        public NativeController(IApiService api, ICovid19Service covid19) : base(api, covid19)
        {
            
        }

    }
}
