using CovidReader.Models.Covid;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Covid.InMemory
{
    public class InMemoryCovidLineItemRepository : InMemoryCovidRepositoryBase<CovidLineItem> , ICovidLineItemRepository
    {

    }
}
