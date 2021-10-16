using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Settings
{
    /// <summary>
    /// ユーザー設定
    /// </summary>
    public interface ISettingRepository
    {
        /// <summary>
        /// コンフィグレーション
        /// </summary>
        IConfigRepository Configs { get; }
    }
}
