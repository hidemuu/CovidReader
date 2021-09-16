using CovidReader.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Api.Json
{
    public class JsonInspectionRepository : JsonApiRepositoryBase<Inspection>, IInspectionRepository
    {
        public JsonInspectionRepository(string filename, string encode = "utf-8") : base(filename, encode) { }
    }
}
