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

        public override string ToString() => 
            Date.ToString() + Formats.Delimiter + 
            Name.ToString() + Formats.Delimiter +
            DeathNumber.ToString() + Formats.Delimiter +
            HospitalizationNumber.ToString() + Formats.Delimiter +
            PositiveNumber.ToString() + Formats.Delimiter +
            RecoveryNumber.ToString() + Formats.Delimiter +
            SevereNumber.ToString() + Formats.Delimiter +
            TestNumber.ToString();

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
