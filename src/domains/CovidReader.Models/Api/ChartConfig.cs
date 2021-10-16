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
    /// チャート各カラムのコンフィグ（オプション）データ
    /// </summary>
    public class ChartConfig : DbObject
    {
        
        /// <summary>
        /// チャートタイプ（ライン/バー等）
        /// </summary>
        [Name("chart_type")]
        [JsonProperty("chart_type")]
        [DisplayName("チャートタイプ")]
        public string ChartType { get; set; } = "line";
        /// <summary>
        /// 背景色
        /// </summary>
        [Name("background_color")]
        [JsonProperty("background_color")]
        [DisplayName("バックグラウンドカラー")]
        public string BackgroundColor { get; set; }
        /// <summary>
        /// ボーダー色
        /// </summary>
        [Name("border_color")]
        [JsonProperty("border_color")]
        [DisplayName("ボーダーカラー")]
        public string BorderColor { get; set; }
        /// <summary>
        /// ボーダー幅
        /// </summary>
        [Name("border_width")]
        [JsonProperty("border_width")]
        [DisplayName("ボーダーサイズ")]
        public int BorderWidth { get; set; }
        /// <summary>
        /// カテゴリ（区分用）
        /// </summary>
        [Name("category")]
        [JsonProperty("category")]
        [DisplayName("カテゴリ")]
        public int Category { get; set; } = 0;
        /// <summary>
        /// 文字列取得
        /// </summary>
        /// <returns></returns>
        public override string ToString() =>
            Name.ToString() + Formats.Delimiter +
            ChartType.ToString() + Formats.Delimiter +
            BackgroundColor.ToString() + Formats.Delimiter +
            BorderColor.ToString() + Formats.Delimiter +
            BorderWidth.ToString() + Formats.Delimiter +
            Category.ToString();
        /// <summary>
        /// ヘッダー文字列取得
        /// </summary>
        /// <returns></returns>
        public static string GetHeader() =>
            "名称" + Formats.Delimiter +
            "チャートタイプ" + Formats.Delimiter +
            "バックグラウンドカラー" + Formats.Delimiter +
            "ボーダーカラー" + Formats.Delimiter +
            "ボーダーサイズ" + Formats.Delimiter +
            "カテゴリ";
    }
}
