using CovidReader.Models.Covid19.MHLW;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Covid19.MHLW.InMemory
{
    public class InMemoryCovid19LineItemRepository : InMemoryCovid19RepositoryBase<Covid19LineItem> , ICovid19LineItemRepository
    {
        public InMemoryCovid19LineItemRepository() : base() { }
    }
}
