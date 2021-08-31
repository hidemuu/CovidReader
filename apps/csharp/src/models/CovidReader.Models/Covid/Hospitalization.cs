using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CovidReader.Models.Covid
{
    public class Hospitalization : CovidDbObject
    {
        [Index(1)]
        [Name("入院治療を要する者")]
        [JsonProperty("入院治療を要する者")]
        [DisplayName("入院治療を要する者")]
        public override string Number { get; set; }

        //public CovidLineItem CovidLineItem { get; set; }

        public override string ToString() => Date.ToString() + Formats.Delimiter + Number.ToString();

        public static string GetHeader() => "日付" + Formats.Delimiter + "入院治療を要する者";
    }
}
