using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Covid.Csv
{
    public class CsvCovidRepository : ICovidRepository
    {
        private readonly string _path;
        private readonly string _encode;

        public CsvCovidRepository(string path, string encode = "utf-8")
        {
            _path = Urls.RootPath + path + @"\";
            _encode = encode;
        }

        public IDeathRepository Deathes =>
            new CsvDeathRepository(_path + @"death_total.csv", _encode);

        public IHospitalizationRepository Hospitalizations =>
            new CsvHospitalizationRepository(_path + @"cases_total.csv", _encode);

        public IPositiveRepository Positives =>
            new CsvPositiveRepository(_path + @"pcr_positive_daily.csv", _encode);

        public IRecoveryRepository Recoveries =>
            new CsvRecoveryRepository(_path + @"recovery_total.csv", _encode);

        public ISevereRepository Severes =>
            new CsvSevereRepository(_path + @"death_total.csv", _encode);

        public ITestDetailRepository TestDetails =>
            new CsvTestDetailRepository(_path + @"pcr_case_daily.csv", _encode);

        public ITestRepository Tests =>
            new CsvTestRepository(_path + @"pcr_tested_daily.csv", _encode);

        public ICovidLineItemRepository CovidLineItems =>
           new CsvCovidLineItemRepository(_path + @"line_item.csv", _encode);

    }
}
