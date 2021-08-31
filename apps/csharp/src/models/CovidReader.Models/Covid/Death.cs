using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CovidReader.Models.Covid
{
    public class Death : CovidDbObject
    {
        [Index(1)]
        [Name("死亡者数")]
        [JsonProperty("死亡者数")]
        [DisplayName("死亡者数")]
        public override string Number { get; set; }

        //public CovidLineItem CovidLineItem { get; set; }

        public override string ToString() => Date.ToString() + Formats.Delimiter + Number.ToString();

        public static string GetHeader() => "日付" + Formats.Delimiter + "死亡者数";

    }
}
