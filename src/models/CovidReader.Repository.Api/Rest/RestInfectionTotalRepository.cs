using CovidReader.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Api.Rest
{
    public class RestInfectionTotalRepository : RestApiRepositoryBase<InfectionTotal>, IInfectionTotalRepository
    {
        public RestInfectionTotalRepository(string url, string key) : base(url, key, "infection_total") { }
    }
}
