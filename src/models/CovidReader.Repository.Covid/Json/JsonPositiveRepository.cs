using CovidReader.Models.Covid;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Covid.Json
{
    public class JsonPositiveRepository : JsonCovidRepositoryBase<Positive>, IPositiveRepository
    {
        public JsonPositiveRepository(string filename, string encode = "utf-8") : base(filename, encode)
        {

        }
    }
}
