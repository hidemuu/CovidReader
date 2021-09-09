using CovidReader.Models.Covid19.MHLW;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Covid19.MHLW.Json
{
    public class JsonHospitalizationRepository : JsonCovidRepositoryBase<Hospitalization>, IHospitalizationRepository
    {
        public JsonHospitalizationRepository(string filename, string encode = "utf-8") : base(filename, encode)
        {

        }
    }
}
