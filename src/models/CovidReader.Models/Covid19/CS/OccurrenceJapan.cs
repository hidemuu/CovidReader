using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CovidReader.Models.Covid19.CS
{
    public class OccurrenceJapan : CovidDbObject
    {
        [Index(1)]
        [Name("npatients")]
        [JsonProperty("npatients")]
        [DisplayName("累積感染者数")]
        public override string Number { get; set; }
        [Index(2)]
        [Name("name_jp")]
        [JsonProperty("name_jp")]
        [DisplayName("都道府県名")]
        public string Area { get; set; }
    }
}
