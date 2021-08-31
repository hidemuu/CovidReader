using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CovidReader.Models.Covid
{
    public class Severe : CovidDbObject 
    {
        [Index(1)]
        [Name("重症者数")]
        [JsonProperty("重症者数")]
        [DisplayName("重症者数")]
        public override string Number { get; set; }

        public override string ToString() => Date.ToString() + Formats.Delimiter + Number.ToString();

        public static string GetHeader() => "日付" + Formats.Delimiter + "重症者数";
    }
}
