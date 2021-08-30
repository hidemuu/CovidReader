using CovidReader.Models.Covid;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Covid.Json
{
    public class JsonTestRepository : JsonCovidRepositoryBase<Test>, ITestRepository
    {
        public JsonTestRepository(string filename, string encode = "utf-8") : base(filename, encode)
        {

        }
    }
}
