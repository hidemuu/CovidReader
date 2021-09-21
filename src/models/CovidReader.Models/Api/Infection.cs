using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CovidReader.Models.Api
{
    /// <summary>
    /// 感染状況
    /// </summary>
    public class Infection : DailyDbObject
    {
        /// <summary>
        /// 国名
        /// </summary>
        [Name("country_name")]
        [JsonProperty("country_name")]
        [DisplayName("国名")]
        public string CountryName { get; set; } = "";
        /// <summary>
        /// 都道府県名
        /// </summary>
        [Name("pref_name")]
        [JsonProperty("pref_name")]
        [DisplayName("都道府県名")]
        public string PrefName { get; set; } = "";
        /// <summary>
        /// 市名
        /// </summary>
        [Name("city_name")]
        [JsonProperty("city_name")]
        [DisplayName("市名")]
        public string CityName { get; set; } = "";
        /// <summary>
        /// 死亡者数
        /// </summary>
        [Name("death_number")]
        [JsonProperty("death_number")]
        [DisplayName("死亡者数")]
        public int DeathNumber { get; set; } = 0;
        /// <summary>
        /// 入院者数
        /// </summary>
        [Name("cure_number")]
        [JsonProperty("cure_number")]
        [DisplayName("入院者数")]
        public int CureNumber { get; set; } = 0;
        /// <summary>
        /// 陽性者数
        /// </summary>
        [Name("patient_number")]
        [JsonProperty("patient_number")]
        [DisplayName("陽性者数")]
        public int PatientNumber { get; set; } = 0;
        /// <summary>
        /// 退院者数
        /// </summary>
        [Name("recovery_number")]
        [JsonProperty("recovery_number")]
        [DisplayName("退院者数")]
        public int RecoveryNumber { get; set; } = 0;
        /// <summary>
        /// 重傷者数
        /// </summary>
        [Name("severe_number")]
        [JsonProperty("severe_number")]
        [DisplayName("重症者数")]
        public int SevereNumber { get; set; } = 0;
        /// <summary>
        /// 検査件数
        /// </summary>
        [Name("test_number")]
        [JsonProperty("test_number")]
        [DisplayName("検査件数")]
        public int TestNumber { get; set; } = 0;
        /// <summary>
        /// 文字列取得
        /// </summary>
        /// <returns></returns>
        public override string ToString() =>
            Date.ToString() + Formats.Delimiter +
            DeathNumber.ToString() + Formats.Delimiter +
            CureNumber.ToString() + Formats.Delimiter +
            PatientNumber.ToString() + Formats.Delimiter +
            RecoveryNumber.ToString() + Formats.Delimiter +
            SevereNumber.ToString() + Formats.Delimiter +
            TestNumber.ToString();
        /// <summary>
        /// ヘッダー文字列取得
        /// </summary>
        /// <returns></returns>
        public static string GetHeader() =>
            "日付" + Formats.Delimiter +
            "名称" + Formats.Delimiter +
            "死亡者数" + Formats.Delimiter +
            "入院者数" + Formats.Delimiter +
            "陽性者数" + Formats.Delimiter +
            "退院者数" + Formats.Delimiter +
            "重傷者数" + Formats.Delimiter +
            "検査件数";
    }
}
