using CovidReader.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Api.Json
{
    public class JsonInfectionRepository : JsonApiDailyRepositoryBase<Infection>, IInfectionRepository
    {
        public JsonInfectionRepository(string filename, string encode = "utf-8") : base(filename, encode) { }
    }
}
