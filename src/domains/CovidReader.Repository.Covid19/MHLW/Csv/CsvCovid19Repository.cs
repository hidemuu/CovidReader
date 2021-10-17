using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Covid19.MHLW.Csv
{
    public class CsvCovid19Repository : ICovid19Repository, ICovid19Mapper
    {
        private readonly string _path;
        private readonly string _encode;

        public CsvCovid19Repository(string path, string encode = "utf-8")
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

        public ICovid19LineItemRepository CovidLineItems =>
           new CsvCovid19LineItemRepository(_path + @"line_item.csv", _encode);

    }
}
