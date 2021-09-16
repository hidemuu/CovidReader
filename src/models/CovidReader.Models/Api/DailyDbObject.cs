using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CovidReader.Models.Api
{
    public class DailyDbObject : DbObject
    {
        
        [Name("index")]
        [JsonProperty("index")]
        [DisplayName("項目")]
        [Required]
        public int Index { get; set; }

        [Name("date")]
        [JsonProperty("date")]
        [DisplayName("日付")]
        [Required]
        public string Date { get; set; }
        [Name("calc")]
        [JsonProperty("calc")]
        [DisplayName("集計方法")]
        public string Calc { get; set; } = "daily";
    }
}
