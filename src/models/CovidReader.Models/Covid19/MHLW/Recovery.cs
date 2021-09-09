using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CovidReader.Models.Covid19.MHLW
{
    public class Recovery : CovidDbObject 
    {
        [Index(1)]
        [Name("退院、療養解除となった者")]
        [JsonProperty("退院、療養解除となった者")]
        [DisplayName("退院、療養解除となった者")]
        public override string Number { get; set; }

        public override string ToString() => Date.ToString() + Formats.Delimiter + Number.ToString();

        public static string GetHeader() => "日付" + Formats.Delimiter + "退院、療養解除となった者";
    }
}
