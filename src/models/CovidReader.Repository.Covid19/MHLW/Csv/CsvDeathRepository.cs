using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CovidReader.Models.Covid19.MHLW;
using CovidReader.Repository;
using CsvHelper.Configuration;

namespace CovidReader.Repository.Covid19.MHLW.Csv
{
    public class CsvDeathRepository : CsvCovidRepositoryBase<Death>, IDeathRepository
    {

        public CsvDeathRepository(string fileName, string encode = "utf-8") : base(fileName, encode) { }

        
    }
}
