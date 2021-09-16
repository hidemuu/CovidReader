using CovidReader.Models.Covid19.MHLW;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Covid19.MHLW.Rest
{
    public class RestCovid19LineItemRepository : RestCovid19RepositoryBase<CovidLineItem>, ICovid19LineItemRepository
    {
        public RestCovid19LineItemRepository(string url, string key) : base(url, key, "line_item")
        {

        }

    }
}
