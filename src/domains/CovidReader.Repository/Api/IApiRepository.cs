using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Api
{
    /// <summary>
    /// アプリケーションAPIリポジトリ
    /// </summary>
    public interface IApiRepository
    {
        /// <summary>
        /// 感染データリポジトリ
        /// </summary>
        IInfectionRepository Infections { get; }
        /// <summary>
        /// 検査データリポジトリ
        /// </summary>
        IInspectionRepository Inspections { get; }
        /// <summary>
        /// チャート表示データリポジトリ（現在不使用）
        /// </summary>
        IChartItemRepository ChartItems { get; }
        /// <summary>
        /// チャート設定データリポジトリ（現在不使用）
        /// </summary>
        IChartConfigRepository ChartConfigs { get; }
    }
}
