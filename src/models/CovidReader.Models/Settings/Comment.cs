using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CovidReader.Models.Settings
{
    /// <summary>
    /// ユーザーインタフェース表示コメント
    /// </summary>
    public class Comment : SettingDbObject
    {
        /// <summary>
        /// コメントコード（識別用）
        /// </summary>
        public override string Name { get; set; }
        /// <summary>
        /// コメント文字
        /// </summary>
        public override string Val { get; set; }
        /// <summary>
        /// 詳細説明（任意記載）
        /// </summary>
        public string Description { get; set; } = "";
    }
}
