using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CovidReader.Models.Covid19.MHLW
{
    /// <summary>
    /// 累積退院者数
    /// </summary>
    public class Recovery : Covid19DbObject 
    {
        /// <summary>
        /// 退院、療養解除となった者
        /// </summary>
        [Index(1)]
        [Name("退院、療養解除となった者")]
        [JsonProperty("退院、療養解除となった者")]
        [DisplayName("退院、療養解除となった者")]
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
        public static string GetHeader() => "日付" + Formats.Delimiter + "退院、療養解除となった者";
    }
}
