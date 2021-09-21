using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CovidReader.Models.Covid19.MHLW
{
    /// <summary>
    /// 重傷者数
    /// </summary>
    public class Severe : Covid19DbObject 
    {
        /// <summary>
        /// 重症者数
        /// </summary>
        [Index(1)]
        [Name("重症者数")]
        [JsonProperty("重症者数")]
        [DisplayName("重症者数")]
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
        public static string GetHeader() => "日付" + Formats.Delimiter + "重症者数";
    }
}
