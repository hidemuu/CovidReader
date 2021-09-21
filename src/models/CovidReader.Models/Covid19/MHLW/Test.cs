using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CovidReader.Models.Covid19.MHLW
{
    /// <summary>
    /// 単日検査件数
    /// </summary>
    public class Test : Covid19DbObject
    {
        /// <summary>
        /// PCR 検査実施件数(単日)
        /// </summary>
        [Index(1)]
        [Name("PCR 検査実施件数(単日)")]
        [JsonProperty("PCR 検査実施件数(単日)")]
        [DisplayName("PCR 検査実施件数(単日)")]
        public override string Number { get; set; }
        /// <summary>
        /// 文字列取得
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Date.ToString() + Formats.Delimiter + Number.ToString();
        /// <summary>
        /// ヘッダー文字列取得
        /// </summary>
        /// <returns></returns>
        public static string GetHeader() => "日付" + Formats.Delimiter + "PCR 検査実施件数(単日)";
    }
}
