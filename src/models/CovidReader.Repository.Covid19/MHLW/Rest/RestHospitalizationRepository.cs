using CovidReader.Models.Covid19.MHLW;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid19.MHLW.Rest
{
    public class RestHospitalizationRepository : RestCovidRepositoryBase<Hospitalization>, IHospitalizationRepository
    {


        public RestHospitalizationRepository(string url, string key) : base(url, key, "hospitalization-cases")
        {
            
        }

    }
}
