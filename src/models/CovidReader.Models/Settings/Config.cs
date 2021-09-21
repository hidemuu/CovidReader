using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CovidReader.Models.Settings
{
    /// <summary>
    /// コンフィグレーションデータ
    /// </summary>
    [XmlRoot("Config")]
    public class Config : SettingDbObject
    {
        /// <summary>
        /// データコード（識別用）
        /// </summary>
        [XmlElement("Name")]
        public override string Name { get; set; }
        /// <summary>
        /// 設定値
        /// </summary>
        [XmlElement("Val")]
        public override string Val { get; set; }
        /// <summary>
        /// 初期値
        /// </summary>
        [XmlElement("Default")]
        public string Default { get; set; }
        /// <summary>
        /// 詳細説明（任意）
        /// </summary>
        [XmlElement("Description")]
        public string Description { get; set; } = "";
    }
    /// <summary>
    /// 
    /// </summary>
    [XmlRoot("Configs")]
    public class Configs : List<Config> { }
}
