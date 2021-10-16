using CovidReader.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Api.Rest
{
    public class RestInfectionRepository : RestApiRepositoryBase<Infection>, IInfectionRepository
    {
        public RestInfectionRepository(string url, string key) : base(url, key, "infection") { }
    }
}
