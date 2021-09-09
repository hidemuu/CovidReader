using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CovidReader.Models.Covid19.CS
{
    public class ErrorInfo
    {
        [Name("error_flag")]
        [JsonProperty("error_flag")]
        [DisplayName("エラーフラグ")]
        public string ErrorFlag { get; set; } = "";

        [Name("error_code")]
        [JsonProperty("error_code")]
        [DisplayName("エラーコード")]
        public string ErrorCode { get; set; } = "";

        [Name("error_message")]
        [JsonProperty("error_message")]
        [DisplayName("エラーメッセージ")]
        public string ErrorMessage { get; set; } = "";

    }
}
