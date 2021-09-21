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
    /// チャート表示項目
    /// </summary>
    public class ChartItem : DailyDbObject
    {
        /// <summary>
        /// 表示データ（コンマ区切り）
        /// </summary>

        [Name("data")]
        [JsonProperty("data")]
        [DisplayName("データ")]
        public string Data { get; set; }
        /// <summary>
        /// 文字列取得
        /// </summary>
        /// <returns></returns>
        public override string ToString() =>
            Date.ToString() + Formats.Delimiter +
            Data.ToString();
        /// <summary>
        /// ヘッダー文字列取得
        /// </summary>
        /// <returns></returns>
        public static string GetHeader() =>
            "日付" + Formats.Delimiter +
            "データ";
        /// <summary>
        /// 表示データを配列に変換
        /// </summary>
        /// <returns></returns>
        public string[] ToArray() =>
            Data.Split(Formats.Delimiter.ToCharArray());

    }
}
