using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Covid19.MHLW
{
    /// <summary>
    /// Covid19 APIリポジトリ
    /// </summary>
    public interface ICovid19Repository
    {
        /// <summary>
        /// 死亡者数
        /// </summary>
        IDeathRepository Deathes { get; }
        /// <summary>
        /// 入院治療者数
        /// </summary>
        IHospitalizationRepository Hospitalizations { get; }
        /// <summary>
        /// 陽性者数
        /// </summary>
        IPositiveRepository Positives { get; }
        /// <summary>
        /// 治療済者数
        /// </summary>
        IRecoveryRepository Recoveries { get; }
        /// <summary>
        /// 重傷者数
        /// </summary>
        ISevereRepository Severes { get; }
        /// <summary>
        /// 検査件数
        /// </summary>
        ITestRepository Tests { get; }
        /// <summary>
        /// 検査件数詳細
        /// </summary>
        ITestDetailRepository TestDetails { get; }
        /// <summary>
        /// 一覧
        /// </summary>
        ICovid19LineItemRepository CovidLineItems { get; }

    }
}
