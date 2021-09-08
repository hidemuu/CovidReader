using CovidReader.Models.Covid;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Covid.Rest
{
    public class RestCovidLineItemRepository : RestCovidRepositoryBase<CovidLineItem>, ICovidLineItemRepository
    {
        public RestCovidLineItemRepository(string url, string key) : base(url, key, "line_item")
        {

        }

    }
}
