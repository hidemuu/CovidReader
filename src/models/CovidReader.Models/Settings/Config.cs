using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CovidReader.Models.Settings
{
    [XmlRoot("Config")]
    public class Config : SettingDbObject
    {
        [XmlElement("Name")]
        public override string Name { get; set; }
        [XmlElement("Val")]
        public override string Val { get; set; }
        [XmlElement("Default")]
        public string Default { get; set; }
        [XmlElement("Description")]
        public string Description { get; set; }
    }

    [XmlRoot("Configs")]
    public class Configs : List<Config> { }
}
