using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CovidReader.Models.Covid19.MHLW
{
    public class Test : CovidDbObject
    {
        [Index(1)]
        [Name("PCR 検査実施件数(単日)")]
        [JsonProperty("PCR 検査実施件数(単日)")]
        [DisplayName("PCR 検査実施件数(単日)")]
        public override string Number { get; set; }

        public override string ToString() => Date.ToString() + Formats.Delimiter + Number.ToString();

        public static string GetHeader() => "日付" + Formats.Delimiter + "PCR 検査実施件数(単日)";
    }
}
