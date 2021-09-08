using CovidReader.Models.Covid;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Covid.Json
{
    public class JsonHospitalizationRepository : JsonCovidRepositoryBase<Hospitalization>, IHospitalizationRepository
    {
        public JsonHospitalizationRepository(string filename, string encode = "utf-8") : base(filename, encode)
        {

        }
    }
}
