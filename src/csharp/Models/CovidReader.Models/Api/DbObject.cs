using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CovidReader.Models.Api
{
    public class DbObject
    {
        [Name("id")]
        [JsonProperty("id")]
        [DisplayName("id")]
        [Required]
        public int Id { get; set; }

        [Name("date")]
        [JsonProperty("date")]
        [DisplayName("日付")]
        [Key]
        [Required]
        public string Date { get; set; }
    }
}
