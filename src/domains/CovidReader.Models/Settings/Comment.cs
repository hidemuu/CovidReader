using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CovidReader.Models.Settings
{
    /// <summary>
    /// ユーザーインタフェース表示コメント
    /// </summary>
    [XmlRoot("Comment")]
    public class Comment : SettingDbObject
    {
        /// <summary>
        /// コメントコード（識別用）
        /// </summary>
        [XmlElement("Name")]
        public override string Name { get; set; }
        /// <summary>
        /// コメント文字
        /// </summary>
        [XmlElement("Val")]
        public override string Val { get; set; }
        /// <summary>
        /// 詳細説明（任意記載）
        /// </summary>
        [XmlElement("Description")]
        public string Description { get; set; } = "";
    }

    /// <summary>
    /// 
    /// </summary>
    [XmlRoot("Comments")]
    public class Comments : List<Comment> { }
}
