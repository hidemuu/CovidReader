using CovidReader.Models.Covid19.MHLW;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid19.MHLW.Csv
{
    public class CsvTestDetailRepository : CsvCovid19RepositoryBase<TestDetail>, ITestDetailRepository
    {

        public CsvTestDetailRepository(string fileName, string encode = "utf-8") : base(fileName, encode) { }

    }
}
