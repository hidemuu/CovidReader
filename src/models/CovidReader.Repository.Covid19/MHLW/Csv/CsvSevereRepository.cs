using CovidReader.Models.Covid19.MHLW;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid19.MHLW.Csv
{
    public class CsvSevereRepository : CsvCovidRepositoryBase<Severe>, ISevereRepository
    {
        public CsvSevereRepository(string fileName, string encode = "utf-8") : base(fileName, encode) { }

    }
}
