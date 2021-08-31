using CovidReader.Models.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Settings.Xml
{
    public class XmlConfigRepository : XmlSettingRepositoryBase<Config, Configs>, IConfigRepository
    {
        public XmlConfigRepository(string path) : base(path) { }
    }
}
