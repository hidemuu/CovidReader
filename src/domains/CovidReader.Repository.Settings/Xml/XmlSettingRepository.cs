using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Settings.Xml
{
    public class XmlSettingRepository : ISettingRepository
    {
        private readonly string _path;

        public XmlSettingRepository(string path)
        {
            _path = Urls.RootPath + path + @"\";
        }

        public IConfigRepository Configs =>
            new XmlConfigRepository(_path + @"configs.xml");

    }
}
