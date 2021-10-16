using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CovidReader.Models.Settings
{
    /// <summary>
    /// ユーザー初期設定データベース共通項目
    /// </summary>
    public class SettingDbObject
    {
        /// <summary>
        /// ID
        /// </summary>
        [XmlElement("Id")]
        public int Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [XmlElement("Name")]
        public virtual string Name { get; set; }
        /// <summary>
        /// 設定値
        /// </summary>
        [XmlElement("Val")]
        public virtual string Val { get; set; }
    }
}
