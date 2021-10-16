using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CovidReader.Models.Api
{
    /// <summary>
    /// 検査件数データ
    /// </summary>
    public class Inspection : DailyDbObject
    {
        /// <summary>
        /// 国名
        /// </summary>
        [Name("country_name")]
        [JsonProperty("country_name")]
        [DisplayName("国名")]
        public string CountryName { get; set; } = "";
        /// <summary>
        /// 国立感染症研究所 検査件数
        /// </summary>
        [Name("national_test_number")]
        [JsonProperty("national_test_number")]
        [DisplayName("国立感染症研究所 検査件数")]
        public int NationalTestNumber { get; set; }
        /// <summary>
        /// 検疫所 検査件数
        /// </summary>
        [Name("quarantine_test_number")]
        [JsonProperty("quarantine_test_number")]
        [DisplayName("検疫所 検査件数")]
        public int QuarantineTestNumber { get; set; }
        /// <summary>
        /// 地方衛生研究所・保健所 検査件数
        /// </summary>
        [Name("carecenter_test_number")]
        [JsonProperty("carecenter_test_number")]
        [DisplayName("地方衛生研究所・保健所 検査件数")]
        public int CareCenterTestNumber { get; set; }
        /// <summary>
        /// 民間検査会社 検査件数
        /// </summary>
        [Name("civilcenter_test_number")]
        [JsonProperty("civilcenter_test_number")]
        [DisplayName("民間検査会社 検査件数")]
        public int CivilCenterTestNumber { get; set; }
        /// <summary>
        /// 大学等 検査件数
        /// </summary>
        [Name("college_test_number")]
        [JsonProperty("college_test_number")]
        [DisplayName("大学等 検査件数")]
        public int CollegeTestNumber { get; set; }
        /// <summary>
        /// 医療機関 検査件数
        /// </summary>
        [Name("medical_test_number")]
        [JsonProperty("medical_test_number")]
        [DisplayName("医療機関 検査件数")]
        public int MedicalTestNumber { get; set; }
        /// <summary>
        /// 文字列取得
        /// </summary>
        /// <returns></returns>
        public override string ToString() =>
            Date.ToString() + Formats.Delimiter +
            NationalTestNumber.ToString() + Formats.Delimiter +
            QuarantineTestNumber.ToString() + Formats.Delimiter +
            CareCenterTestNumber.ToString() + Formats.Delimiter +
            CivilCenterTestNumber.ToString() + Formats.Delimiter +
            CollegeTestNumber.ToString() + Formats.Delimiter +
            MedicalTestNumber.ToString();
        /// <summary>
        /// ヘッダー文字列取得
        /// </summary>
        /// <returns></returns>
        public static string GetHeader() =>
            "日付" + Formats.Delimiter +
            "国立感染症研究所 検査件数" + Formats.Delimiter +
            "検疫所 検査件数" + Formats.Delimiter +
            "地方衛生研究所・保健所 検査件数" + Formats.Delimiter +
            "民間検査会社 検査件数" + Formats.Delimiter +
            "大学等 検査件数" + Formats.Delimiter +
            "医療機関 検査件数";
    }
}
