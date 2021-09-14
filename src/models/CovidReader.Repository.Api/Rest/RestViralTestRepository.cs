using CovidReader.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Api.Rest
{
    public class RestViralTestRepository : RestApiRepositoryBase<ViralTest>, IViralTestRepository
    {
        public RestViralTestRepository(string url, string key) : base(url, key, "viraltest") { }
    }
}
