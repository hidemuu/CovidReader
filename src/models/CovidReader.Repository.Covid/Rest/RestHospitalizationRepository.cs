using CovidReader.Models.Covid;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid
{
    public class RestHospitalizationRepository : RestCovidRepositoryBase<Hospitalization>, IHospitalizationRepository
    {


        public RestHospitalizationRepository(string url, string key) : base(url, key, "hospitalization-cases")
        {
            
        }

    }
}
