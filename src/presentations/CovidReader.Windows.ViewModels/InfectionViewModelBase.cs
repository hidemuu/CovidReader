using CovidReader.Models.Api;
using CovidReader.Repository.Api;
using CovidReader.Windows.Models;
using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Windows.ViewModels
{
    public abstract class InfectionViewModelBase : ApiViewModelBase
    {

        #region フィールド
        /// <summary>
        /// 取得感染データ
        /// </summary>
        private readonly IEnumerable<Infection> originals;
        /// <summary>
        /// 編集感染データ
        /// </summary>
        private IEnumerable<Infection> edits;

        #endregion

        #region プロパティ
        /// <summary>
        /// 感染データ表示モデル
        /// </summary>
        protected ObservableCollection<Infection> Infections { get; set; }
        
        /// <summary>
        /// ビュー選択アイテム
        /// </summary>
        public ReactiveProperty<InfectionModel> SelectedItem { get; set; }

        #endregion

        #region コマンド

        public ReactiveCommand ClearFilterCommand { get; } = new ReactiveCommand();
        public ReactiveCommand WeeklyFilterCommand { get; } = new ReactiveCommand();
        public ReactiveCommand MonthlyFilterCommand { get; } = new ReactiveCommand();
        public ReactiveCommand YearlyFilterCommand { get; } = new ReactiveCommand();
        public ReactiveCommand DailyFilterCommand { get; } = new ReactiveCommand();
        public ReactiveCommand TotalFilterCommand { get; } = new ReactiveCommand();

        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="regionManager"></param>
        /// <param name="apiRepository"></param>
        public InfectionViewModelBase(IRegionManager regionManager, IApiRepository apiRepository) : base(regionManager, apiRepository)
        {
            var task = this.apiRepository.Infections.GetAsync();
            Task.WaitAll(task);
            originals = task.Result;

            Infections = new ObservableCollection<Infection>();
            Filter("", "");
            //Filter("daily", "week");

            ClearFilterCommand.Subscribe(_ => Filter("", ""));
            YearlyFilterCommand.Subscribe(_ => FilterDate("year"));
            MonthlyFilterCommand.Subscribe(_ => FilterDate("month"));
            WeeklyFilterCommand.Subscribe(_ => FilterDate("week"));
            DailyFilterCommand.Subscribe(_ => FilterCategory("daily"));
            TotalFilterCommand.Subscribe(_ => FilterCategory("total"));
        }

        #region 内部メソッド

        protected void Filter(string category, string date)
        {
            FilterCategory(category);
            FilterDate(date);
        }

        /// <summary>
        /// 日付フィルタ
        /// </summary>
        /// <param name="filter"></param>
        private void FilterDate(string filter)
        {
            var date = edits.Max(x => DateTime.Parse(x.Date));
            Infections.Clear();
            switch (filter)
            {
                case "year":
                    Infections.AddRange(edits.Where(x => date.AddDays(-365) < DateTime.Parse(x.Date) && DateTime.Parse(x.Date) < date)); break;
                case "month":
                    Infections.AddRange(edits.Where(x => date.AddDays(-30) < DateTime.Parse(x.Date) && DateTime.Parse(x.Date) < date)); break;
                case "week":
                    Infections.AddRange(edits.Where(x => date.AddDays(-7) < DateTime.Parse(x.Date) && DateTime.Parse(x.Date) < date)); break;
                default:
                    Infections.AddRange(edits); break;
            }
        }

        /// <summary>
        /// カテゴリフィルタ
        /// </summary>
        /// <param name="filter"></param>
        private void FilterCategory(string filter)
        {

            Infections.Clear();
            switch (filter)
            {
                case "daily": edits = originals.Where(x => x.Calc == "daily"); break;
                case "total": edits = originals.Where(x => x.Calc == "total"); break;
                default: edits = originals; break;
            }
            Infections.AddRange(edits);
        }

        #endregion

    }
}
