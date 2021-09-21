using CovidReader.Models.Covid19.MHLW;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Covid19.MHLW.Csv
{
    public class CsvCovid19LineItemRepository : CsvCovid19RepositoryBase<Covid19LineItem> , ICovid19LineItemRepository
    {
        public CsvCovid19LineItemRepository(string fileName, string encode = "utf-8") : base(fileName, encode) { }
    }
}
