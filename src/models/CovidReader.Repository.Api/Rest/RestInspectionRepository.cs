using CovidReader.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Api.Rest
{
    public class RestInspectionRepository : RestApiRepositoryBase<Inspection>, IInspectionRepository
    {
        public RestInspectionRepository(string url, string key) : base(url, key, "viraltest") { }
    }
}
