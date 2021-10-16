using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CovidReader.Models.Api
{ 
    /// <summary>
    /// データベース共通項目
    /// </summary>
    public class DbObject
    {
        /// <summary>
        /// ID
        /// </summary>
        [Name("id")]
        [JsonProperty("id")]
        [DisplayName("id")]
        [Key]
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// データ名
        /// </summary>
        [Name("name")]
        [JsonProperty("name")]
        [DisplayName("name")]
        public string Name { get; set; } = "";
    }
}
