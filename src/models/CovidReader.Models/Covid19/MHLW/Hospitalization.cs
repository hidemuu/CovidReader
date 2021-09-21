using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CovidReader.Models.Covid19.MHLW
{
    /// <summary>
    /// 単日入院治療者数
    /// </summary>
    public class Hospitalization : Covid19DbObject
    {
        /// <summary>
        /// 入院治療を要する者
        /// </summary>
        [Index(1)]
        [Name("入院治療を要する者")]
        [JsonProperty("入院治療を要する者")]
        [DisplayName("入院治療を要する者")]
        public override string Number { get; set; }

        //public CovidLineItem CovidLineItem { get; set; }

        /// <summary>
        /// 文字列取得
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Date.ToString() + Formats.Delimiter + Number.ToString();

        /// <summary>
        /// ヘッダー文字列取得
        /// </summary>
        /// <returns></returns>
        public static string GetHeader() => "日付" + Formats.Delimiter + "入院治療を要する者";
    }
}
