using CovidReader.Models.Covid;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Covid.Csv
{
    public class CsvCovidLineItemRepository : CsvCovidRepositoryBase<CovidLineItem> , ICovidLineItemRepository
    {
        public CsvCovidLineItemRepository(string fileName, string encode = "utf-8") : base(fileName, encode) { }
    }
}
