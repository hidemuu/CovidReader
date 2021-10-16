using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CovidReader.Models.Covid19.MHLW
{
    /// <summary>
    /// 累積死亡者数
    /// </summary>
    public class Death : Covid19DbObject
    {
        /// <summary>
        /// 死亡者数
        /// </summary>
        [Index(1)]
        [Name("死亡者数")]
        [JsonProperty("死亡者数")]
        [DisplayName("死亡者数")]
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
        public static string GetHeader() => "日付" + Formats.Delimiter + "死亡者数";

    }
}
