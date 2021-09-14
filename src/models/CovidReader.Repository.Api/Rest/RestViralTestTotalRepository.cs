using CovidReader.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Api.Rest
{
    public class RestViralTestTotalRepository : RestApiRepositoryBase<ViralTestTotal>, IViralTestTotalRepository
    {
        public RestViralTestTotalRepository(string url, string key) : base(url, key, "viraltest_total") { }
    }
}
