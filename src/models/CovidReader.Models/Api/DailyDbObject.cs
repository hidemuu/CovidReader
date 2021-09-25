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
    /// 日集計データ共通項目
    /// </summary>
    public class DailyDbObject
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
        /// インデックス番号
        /// </summary>
        [Name("index")]
        [JsonProperty("index")]
        [DisplayName("項目")]
        [Required]
        public int Index { get; set; }

        /// <summary>
        /// 日付
        /// </summary>
        [Name("date")]
        [JsonProperty("date")]
        [DisplayName("日付")]
        [Required]
        public string Date { get; set; }
        /// <summary>
        /// 集計方法（単日 / 累計）
        /// </summary>
        [Name("calc")]
        [JsonProperty("calc")]
        [DisplayName("集計方法")]
        public string Calc { get; set; } = "daily";
    }
}
