using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Service
{
    /// <summary>
    /// アプリケーションAPIアクセスサービス
    /// </summary>
    public interface IApiService
    {
        /// <summary>
        /// チャート設定
        /// </summary>
        IChartConfigService ChartConfig { get; }
        /// <summary>
        /// チャート表示アイテム
        /// </summary>
        IChartItemService ChartItem { get; }
        /// <summary>
        /// 感染データ
        /// </summary>
        IInfectionService Infection { get; }
        /// <summary>
        /// 検査データ
        /// </summary>
        IInspectionService Inspection { get; }
        /// <summary>
        /// ChartItemをXAMPPサーバ内にコピー
        /// </summary>
        void CopyChartItem();
        /// <summary>
        /// XAMPPサーバを起動
        /// </summary>
        /// <returns></returns>
        bool RunServerProcess();

    }
}
