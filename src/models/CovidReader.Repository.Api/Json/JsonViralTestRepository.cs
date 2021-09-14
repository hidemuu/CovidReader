using CovidReader.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Api.Json
{
    public class JsonViralTestRepository : JsonApiRepositoryBase<ViralTest>, IViralTestRepository
    {
        public JsonViralTestRepository(string filename, string encode = "utf-8") : base(filename, encode) { }
    }
}
