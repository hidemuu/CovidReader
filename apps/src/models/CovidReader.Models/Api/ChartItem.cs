using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CovidReader.Models.Api
{
    public class ChartItem : DbObject
    {
        

        [Name("data")]
        [JsonProperty("data")]
        [DisplayName("データ")]
        public string Data { get; set; }

        public override string ToString() =>
            Date.ToString() + Formats.Delimiter +
            Data.ToString();

        public static string GetHeader() =>
            "日付" + Formats.Delimiter +
            "データ";

        public string[] ToArray() =>
            Data.Split(Formats.Delimiter.ToCharArray());

    }
}
