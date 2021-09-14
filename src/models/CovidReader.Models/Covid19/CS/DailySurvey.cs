using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Models.Covid19.CS
{
    public class DailySurvey
    {
        public string FacilityId { get; set; }
        public string FacilityName { get; set; }
        public string ZipCode { get; set; }
        public string PrefName { get; set; }
        public string FacilityAddr { get; set; }
        public string FacilityTel { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string SubmitDate { get; set; }
        public string FacilityType { get; set; }
        public string AnsType { get; set; }
        public string LocalGovCode { get; set; }
        public string CityName { get; set; }
        public string FacilityCode { get; set; }
    }
}
