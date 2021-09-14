using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CovidReader.Models.Covid19.CS
{
    public class CovidDbObject
    {
        [Index(0)]
        [Name("date")]
        [JsonProperty("date")]
        [DisplayName("日付")]
        [Key]
        [Required]
        public string Date { get; set; }

        public virtual string Number { get; set; }
    }
}
