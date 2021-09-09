using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CovidReader.Models.Covid19.MHLW
{
    public class CovidDbObject
    {
        [Index(0)]
        [Name("日付")]
        [JsonProperty("日付")]
        [DisplayName("日付")]
        [Key]
        [Required]
        public string Date { get; set; }

        public virtual string Number { get; set; }

    }
}
