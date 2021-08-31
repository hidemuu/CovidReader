using CovidReader.Models.Covid;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid.Csv
{
    public class CsvTestDetailRepository : CsvCovidRepositoryBase<TestDetail>, ITestDetailRepository
    {

        public CsvTestDetailRepository(string fileName, string encode = "utf-8") : base(fileName, encode) { }

    }
}
