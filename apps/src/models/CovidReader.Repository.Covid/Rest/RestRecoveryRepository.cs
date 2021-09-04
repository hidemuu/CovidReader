using CovidReader.Models.Covid;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid
{
    public class RestRecoveryRepository : RestCovidRepositoryBase<Recovery>, IRecoveryRepository
    {


        public RestRecoveryRepository(string url, string key) : base(url, key, "recovery-cases")
        {
            
        }

    }
}
