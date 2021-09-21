using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Models.Covid19.CS
{
    /// <summary>
    /// 施設別の感染情報日報
    /// </summary>
    public class DailySurvey
    {
        /// <summary>
        /// 施設ID
        /// </summary>
        public string FacilityId { get; set; }
        /// <summary>
        /// 施設名
        /// </summary>
        public string FacilityName { get; set; }
        /// <summary>
        /// 住所
        /// </summary>
        public string ZipCode { get; set; }
        /// <summary>
        /// 都道府県名
        /// </summary>
        public string PrefName { get; set; }
        /// <summary>
        /// アドレス
        /// </summary>
        public string FacilityAddr { get; set; }
        /// <summary>
        /// 電話番号
        /// </summary>
        public string FacilityTel { get; set; }
        /// <summary>
        /// 緯度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        /// 経度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        /// 登録日
        /// </summary>
        public string SubmitDate { get; set; }
        /// <summary>
        /// 施設種別
        /// </summary>
        public string FacilityType { get; set; }
        /// <summary>
        /// 解答種別
        /// </summary>
        public string AnsType { get; set; }
        /// <summary>
        /// 政府コード
        /// </summary>
        public string LocalGovCode { get; set; }
        /// <summary>
        /// 市名
        /// </summary>
        public string CityName { get; set; }
        /// <summary>
        /// 設備コード
        /// </summary>
        public string FacilityCode { get; set; }
    }
}
