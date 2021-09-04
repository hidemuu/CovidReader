using CovidReader.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Api.Rest
{
    public class RestVirusRepository : RestApiRepositoryBase<Virus> , IVirusRepository
    {
        public RestVirusRepository(string url, string key) : base(url, key, "virus") { }

    }
}
