using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CovidReader.Models.Covid19.CS
{
    public class OccurrenceOversea : CovidDbObject
    {
        [Index(1)]
        [Name("infectedNum")]
        [JsonProperty("infectedNum")]
        [DisplayName("感染者数")]
        public override string Number { get; set; }
        [Index(2)]
        [Name("deceasedNum")]
        [JsonProperty("deceasedNum")]
        [DisplayName("死亡者数")]
        public string DeathNumber { get; set; }

        [Index(3)]
        [Name("dataName")]
        [JsonProperty("dataname")]
        [DisplayName("国名")]
        public string Area { get; set; }
    }
}
