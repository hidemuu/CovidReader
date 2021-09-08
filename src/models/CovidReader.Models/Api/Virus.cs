using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CovidReader.Models.Api
{
    public class Virus : DbObject
    {

        [Name("name")]
        [JsonProperty("name")]
        [DisplayName("名称")]
        public string Name { get; set; } = "";
        
        [Name("death_number")]
        [JsonProperty("death_number")]
        [DisplayName("死亡者数")]
        public int DeathNumber { get; set; }
        
        [Name("hospitalization_number")]
        [JsonProperty("hospitalization_number")]
        [DisplayName("入院者数")]
        public int HospitalizationNumber { get; set; }
        
        [Name("positive_number")]
        [JsonProperty("positive_number")]
        [DisplayName("陽性者数")]
        public int PositiveNumber { get; set; }
        
        [Name("recovery_number")]
        [JsonProperty("recovery_number")]
        [DisplayName("退院者数")]
        public int RecoveryNumber { get; set; }
        
        [Name("severe_number")]
        [JsonProperty("severe_number")]
        [DisplayName("重症者数")]
        public int SevereNumber { get; set; }
        
        [Name("test_number")]
        [JsonProperty("test_number")]
        [DisplayName("検査件数")]
        public int TestNumber { get; set; }

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
            Name.ToString() + Formats.Delimiter +
            DeathNumber.ToString() + Formats.Delimiter +
            HospitalizationNumber.ToString() + Formats.Delimiter +
            PositiveNumber.ToString() + Formats.Delimiter +
            RecoveryNumber.ToString() + Formats.Delimiter +
            SevereNumber.ToString() + Formats.Delimiter +
            TestNumber.ToString() + Formats.Delimiter +
            NationalTestNumber.ToString() + Formats.Delimiter +
            QuarantineTestNumber.ToString() + Formats.Delimiter +
            CareCenterTestNumber.ToString() + Formats.Delimiter +
            CivilCenterTestNumber.ToString() + Formats.Delimiter +
            CollegeTestNumber.ToString() + Formats.Delimiter +
            MedicalTestNumber.ToString();

        public static string GetHeader() =>
            "日付" + Formats.Delimiter +
            "名称" + Formats.Delimiter +
            "死亡者数" + Formats.Delimiter +
            "入院者数" + Formats.Delimiter +
            "陽性者数" + Formats.Delimiter +
            "退院者数" + Formats.Delimiter +
            "重傷者数" + Formats.Delimiter +
            "検査件数" + Formats.Delimiter +
            "国立感染症研究所 検査件数" + Formats.Delimiter +
            "検疫所 検査件数" + Formats.Delimiter +
            "地方衛生研究所・保健所 検査件数" + Formats.Delimiter +
            "民間検査会社 検査件数" + Formats.Delimiter +
            "大学等 検査件数" + Formats.Delimiter +
            "医療機関 検査件数";
    }
}
