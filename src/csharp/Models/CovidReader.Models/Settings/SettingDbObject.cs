using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CovidReader.Models.Settings
{
    public class SettingDbObject
    {
        [XmlElement("Id")]
        public int Id { get; set; }
        [XmlElement("Name")]
        public virtual string Name { get; set; }
        [XmlElement("Val")]
        public virtual string Val { get; set; }
    }
}
