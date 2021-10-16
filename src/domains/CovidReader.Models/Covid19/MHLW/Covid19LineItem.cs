using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Models.Covid19.MHLW
{
    /// <summary>
    /// 各データの一覧表示
    /// </summary>
    public class Covid19LineItem : Covid19DbObject
    {
        /// <summary>
        /// 死亡者数
        /// </summary>
        public Death Death { get; set; }
        /// <summary>
        /// 入院治療者数
        /// </summary>
        public Hospitalization Hospitalization { get; set; }

    }
}
