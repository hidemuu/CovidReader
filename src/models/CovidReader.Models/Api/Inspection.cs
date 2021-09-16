using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CovidReader.Models.Api
{
    public class Inspection : DailyDbObject
    {
        [Name("country_name")]
        [JsonProperty("country_name")]
        [DisplayName("国名")]
        public string CountryName { get; set; } = "";
        [Name("national_test_number")]
        [JsonProperty("national_test_number")]
        [DisplayName("国立感染症研究所 検査件数")]
        public int NationalTestNumber { get; set; }

        [Name("quarantine_test_number")]
        [JsonProperty("quarantine_test_number")]
        [DisplayName("検疫所 検査件数")]
        public int QuarantineTestNumber { get; set; }

        [Name("carecenter_test_number")]
        [JsonProperty("carecenter_test_number")]
        [DisplayName("地方衛生研究所・保健所 検査件数")]
        public int CareCenterTestNumber { get; set; }

        [Name("civilcenter_test_number")]
        [JsonProperty("civilcenter_test_number")]
        [DisplayName("民間検査会社 検査件数")]
        public int CivilCenterTestNumber { get; set; }

        [Name("college_test_number")]
        [JsonProperty("college_test_number")]
        [DisplayName("大学等 検査件数")]
        public int CollegeTestNumber { get; set; }

        [Name("medical_test_number")]
        [JsonProperty("medical_test_number")]
        [DisplayName("医療機関 検査件数")]
        public int MedicalTestNumber { get; set; }

        public override string ToString() =>
            Date.ToString() + Formats.Delimiter +
            NationalTestNumber.ToString() + Formats.Delimiter +
            QuarantineTestNumber.ToString() + Formats.Delimiter +
            CareCenterTestNumber.ToString() + Formats.Delimiter +
            CivilCenterTestNumber.ToString() + Formats.Delimiter +
            CollegeTestNumber.ToString() + Formats.Delimiter +
            MedicalTestNumber.ToString();

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
