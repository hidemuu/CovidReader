using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CovidReader.Models.Covid19.CS
{
    /// <summary>
    /// 世界の地域別の感染者数、死亡者数
    /// </summary>
    public class OccurrenceOversea : Covid19DbObject
    {
        /// <summary>
        /// 感染者数
        /// </summary>
        [Index(1)]
        [Name("infectedNum")]
        [JsonProperty("infectedNum")]
        [DisplayName("感染者数")]
        public override string Number { get; set; }
        /// <summary>
        /// 死亡者数
        /// </summary>
        [Index(2)]
        [Name("deceasedNum")]
        [JsonProperty("deceasedNum")]
        [DisplayName("死亡者数")]
        public string DeathNumber { get; set; }
        /// <summary>
        /// 国名
        /// </summary>
        [Index(3)]
        [Name("dataName")]
        [JsonProperty("dataname")]
        [DisplayName("国名")]
        public string Area { get; set; }
    }
}
