using CovidReader.Models.Covid19.MHLW;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Covid19.MHLW.Json
{
    public class JsonCovid19LineItemRepository : JsonCovid19RepositoryBase<CovidLineItem> , ICovid19LineItemRepository
    {
        public JsonCovid19LineItemRepository(string filename, string encode = "utf-8") : base(filename, encode) { }
    }
}
