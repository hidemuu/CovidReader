using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CovidReader.Models.Api
{
    public class Infection : DbObject
    {
        [Name("country")]
        [JsonProperty("country")]
        [DisplayName("国名")]
        public string Country { get; set; }
        [Name("area")]
        [JsonProperty("area")]
        [DisplayName("エリア名")]
        public string Area { get; set; }
        [Name("death_number")]
        [JsonProperty("death_number")]
        [DisplayName("死亡者数")]
        public int DeathNumber { get; set; }

        [Name("cure_number")]
        [JsonProperty("cure_number")]
        [DisplayName("入院者数")]
        public int CureNumber { get; set; }

        [Name("patient_number")]
        [JsonProperty("patient_number")]
        [DisplayName("陽性者数")]
        public int PatientNumber { get; set; }

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
    }
}
