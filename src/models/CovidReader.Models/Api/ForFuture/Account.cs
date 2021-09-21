using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Models.Api
{
    /// <summary>
    /// ログイン用アカウント
    /// </summary>
    public class Account : DbObject
    {
        /// <summary>
        /// ログインID
        /// </summary>
        public string LoginId { get; set; }
        /// <summary>
        /// パスワード
        /// </summary>
        public string Password { get; set; }
    }
}
