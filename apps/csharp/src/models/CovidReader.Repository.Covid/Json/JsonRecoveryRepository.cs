using CovidReader.Models.Covid;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Covid.Json
{
    public class JsonRecoveryRepository : JsonCovidRepositoryBase<Recovery>, IRecoveryRepository
    {
        public JsonRecoveryRepository(string filename, string encode = "utf-8") : base(filename, encode)
        {

        }
    }
}
