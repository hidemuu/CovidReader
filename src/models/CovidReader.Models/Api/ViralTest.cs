using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CovidReader.Models.Api
{
    public class ViralTest : DbObject
    {
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
    }
}
