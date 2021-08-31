using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CovidReader.Models.Covid
{
    public class TestDetail : CovidDbObject
    {
        [Index(1)]
        [Name("国立感染症研究所")]
        [JsonProperty("国立感染症研究所")]
        [DisplayName("国立感染症研究所")]
        public override string Number { get; set; }



        public override string ToString() => Date.ToString() + Formats.Delimiter + Number.ToString();

        public static string GetHeader() => "日付" + Formats.Delimiter + "国立感染症研究所";
    }
}
