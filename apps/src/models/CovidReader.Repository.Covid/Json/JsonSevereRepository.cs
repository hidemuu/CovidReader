using CovidReader.Models.Covid;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Covid.Json
{
    public class JsonSevereRepository : JsonCovidRepositoryBase<Severe>, ISevereRepository
    {
        public JsonSevereRepository(string filename, string encode = "utf-8") : base(filename, encode)
        {

        }
    }
}
