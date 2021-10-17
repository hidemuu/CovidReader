using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Covid19.MHLW.Json
{
    public class JsonCovid19Repository : ICovid19Repository, ICovid19Mapper
    {
        private readonly string _path;
        private readonly string _encode;

        public JsonCovid19Repository(string path, string encode = "utf-8")
        {
            _path = Urls.RootPath + path + @"\";
            _encode = encode;
        }

        public IDeathRepository Deathes =>
            new JsonDeathRepository(_path + @"death.json", _encode);

        public IHospitalizationRepository Hospitalizations =>
            new JsonHospitalizationRepository(_path + @"hospitalization.json", _encode);

        public IPositiveRepository Positives =>
            new JsonPositiveRepository(_path + @"positive.json", _encode);

        public IRecoveryRepository Recoveries =>
            new JsonRecoveryRepository(_path + @"recovery.json", _encode);

        public ISevereRepository Severes =>
            new JsonSevereRepository(_path + @"severe.json", _encode);

        public ITestDetailRepository TestDetails =>
            new JsonTestDetailRepository(_path + @"test_detail.json", _encode);

        public ITestRepository Tests =>
            new JsonTestRepository(_path + @"test.json", _encode);

        public ICovid19LineItemRepository CovidLineItems =>
            new JsonCovid19LineItemRepository(_path + @"line_item.json", _encode);

    }
}
