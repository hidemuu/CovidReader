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
        [Key]
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
