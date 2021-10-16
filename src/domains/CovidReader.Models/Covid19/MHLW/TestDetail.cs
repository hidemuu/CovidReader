using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CovidReader.Models.Covid19.MHLW
{
    /// <summary>
    /// 施設別の単日検査件数
    /// </summary>
    public class TestDetail : Covid19DbObject
    {
        /// <summary>
        /// 国立感染症研究所
        /// </summary>
        [Index(1)]
        [Name("国立感染症研究所")]
        [JsonProperty("国立感染症研究所")]
        [DisplayName("国立感染症研究所")]
        public override string Number { get; set; }
        /// <summary>
        /// 検疫所
        /// </summary>
        [Index(2)]
        [Name("検疫所")]
        [JsonProperty("検疫所")]
        [DisplayName("検疫所")]
        public string QuarantineNumber { get; set; }
        /// <summary>
        /// 地方衛生研究所・保健所
        /// </summary>
        [Index(3)]
        [Name("地方衛生研究所・保健所")]
        [JsonProperty("地方衛生研究所・保健所")]
        [DisplayName("地方衛生研究所・保健所")]
        public string CareCenterNumber { get; set; }
        /// <summary>
        /// 民間検査会社
        /// </summary>
        [Index(4)]
        [Name("民間検査会社")]
        [JsonProperty("民間検査会社")]
        [DisplayName("民間検査会社")]
        public string CivilCenterNumber { get; set; }
        /// <summary>
        /// 大学等
        /// </summary>
        [Index(5)]
        [Name("大学等")]
        [JsonProperty("大学等")]
        [DisplayName("大学等")]
        public string CollegeNumber { get; set; }
        /// <summary>
        /// 医療機関
        /// </summary>
        [Index(6)]
        [Name("医療機関")]
        [JsonProperty("医療機関")]
        [DisplayName("医療機関")]
        public string MedicalNumber { get; set; }
        /// <summary>
        /// 文字列取得
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Date.ToString() + Formats.Delimiter + Number.ToString();
        /// <summary>
        /// ヘッダー文字列取得
        /// </summary>
        /// <returns></returns>
        public static string GetHeader() => "日付" + Formats.Delimiter + "国立感染症研究所";
    }
}
