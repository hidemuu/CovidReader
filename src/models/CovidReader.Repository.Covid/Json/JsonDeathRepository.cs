using CovidReader.Models.Covid;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Covid.Json
{
    public class JsonDeathRepository : JsonCovidRepositoryBase<Death>, IDeathRepository
    {
        public JsonDeathRepository(string filename, string encode = "utf-8") : base(filename, encode)
        {

        }
    }
}
