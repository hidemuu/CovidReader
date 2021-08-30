using CovidReader.Models.Covid;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid.Csv
{
    public class CsvRecoveryRepository : CsvCovidRepositoryBase<Recovery>, IRecoveryRepository
    {
        public CsvRecoveryRepository(string fileName, string encode = "utf-8") : base(fileName, encode) { }

    }
}
