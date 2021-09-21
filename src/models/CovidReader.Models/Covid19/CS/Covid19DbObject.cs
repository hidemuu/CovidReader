using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CovidReader.Models.Covid19.CS
{
    /// <summary>
    /// Covid19データベース共通項目
    /// </summary>
    public class Covid19DbObject
    {
        /// <summary>
        /// 日付
        /// </summary>
        [Index(0)]
        [Name("date")]
        [JsonProperty("date")]
        [DisplayName("日付")]
        [Key]
        [Required]
        public string Date { get; set; }
        /// <summary>
        /// 集計数
        /// </summary>
        public virtual string Number { get; set; }
    }
}
