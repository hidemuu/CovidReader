using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CovidReader.Models.Covid19.CS
{
    /// <summary>
    /// 累積死亡者数
    /// </summary>
    public class DeathsJapan : Covid19DbObject
    {
        /// <summary>
        /// 累積死亡者数
        /// </summary>
        [Index(1)]
        [Name("ndeaths")]
        [JsonProperty("ndeaths")]
        [DisplayName("累積死亡者数")]
        public override string Number { get; set; }
    }
}
