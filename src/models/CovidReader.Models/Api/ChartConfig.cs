using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CovidReader.Models.Api
{
    public class ChartConfig : DbObject
    {
        [Name("name")]
        [JsonProperty("name")]
        [DisplayName("名称")]
        public string Name { get; set; } = "";
        [Name("chart_type")]
        [JsonProperty("chart_type")]
        [DisplayName("チャートタイプ")]
        public string ChartType { get; set; } = "line";
        [Name("background_color")]
        [JsonProperty("background_color")]
        [DisplayName("バックグラウンドカラー")]
        public string BackgroundColor { get; set; }
        [Name("border_color")]
        [JsonProperty("border_color")]
        [DisplayName("ボーダーカラー")]
        public string BorderColor { get; set; }
        [Name("border_width")]
        [JsonProperty("border_width")]
        [DisplayName("ボーダーサイズ")]
        public int BorderWidth { get; set; }
        [Name("category")]
        [JsonProperty("category")]
        [DisplayName("カテゴリ")]
        public int Category { get; set; } = 0;

        public override string ToString() =>
            Date.ToString() + Formats.Delimiter +
            Name.ToString() + Formats.Delimiter +
            ChartType.ToString() + Formats.Delimiter +
            BackgroundColor.ToString() + Formats.Delimiter +
            BorderColor.ToString() + Formats.Delimiter +
            BorderWidth.ToString() + Formats.Delimiter +
            Category.ToString();

        public static string GetHeader() =>
            "日付" + Formats.Delimiter +
            "名称" + Formats.Delimiter +
            "チャートタイプ" + Formats.Delimiter +
            "バックグラウンドカラー" + Formats.Delimiter +
            "ボーダーカラー" + Formats.Delimiter +
            "ボーダーサイズ" + Formats.Delimiter +
            "カテゴリ";
    }
}
