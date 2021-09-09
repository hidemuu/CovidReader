using CovidReader.Models.Covid19.MHLW;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Covid19.MHLW.Rest
{
    public class RestCovidLineItemRepository : RestCovidRepositoryBase<CovidLineItem>, ICovidLineItemRepository
    {
        public RestCovidLineItemRepository(string url, string key) : base(url, key, "line_item")
        {

        }

    }
}
