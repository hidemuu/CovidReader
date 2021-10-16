using CovidReader.Models.Covid19.MHLW;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid19.MHLW.Rest
{
    public class RestPositiveRepository : RestCovid19RepositoryBase<Positive>, IPositiveRepository
    {


        public RestPositiveRepository(string url, string key) : base(url, key, "positive-cases")
        {
    
        }


    }
}
