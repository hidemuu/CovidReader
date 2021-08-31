using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CovidReader.Models.Settings
{
    public class Comment : SettingDbObject
    {
        public override string Name { get; set; }

        public override string Val { get; set; }

        public string Description { get; set; }
    }
}
