﻿using CsvHelper.Configuration.Attributes;
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
    }
}
