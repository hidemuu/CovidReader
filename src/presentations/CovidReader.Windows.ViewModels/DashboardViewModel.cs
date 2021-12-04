using CovidReader.Windows.Views;
using CovidReader.Windows.Models.Constants;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CovidReader.Repository.Api;
using Reactive.Bindings;
using CovidReader.Windows.Models;
using LiveCharts;
using LiveCharts.Wpf;

namespace CovidReader.Windows.ViewModels
{
    public class DashboardViewModel : InfectionViewModelBase
    {
        private IRegionNavigationJournal journal;
        public IRegionManager RegionManager { get; }

        #region プロパティ

        /// <summary>
        /// ビューバインディングモデル
        /// </summary>
        public ReadOnlyReactiveCollection<InfectionModel> Models { get; }
        public ReactivePropertySlim<SeriesCollection> Series { get; private set; }
        private IList<InfectionChartModel> models { get; set; } = new List<InfectionChartModel>();

        #endregion

        public DashboardViewModel(IRegionManager regionManager, IApiRepository apiRepository) : base(regionManager, apiRepository)
        {
            this.Models = Infections.ToReadOnlyReactiveCollection(c => new InfectionModel(c));
            Filter("total", "year");
            models.Add(new InfectionChartModel("patient", new ChartValues<int>(Infections.Select(x => x.PatientNumber))));
            models.Add(new InfectionChartModel("death", new ChartValues<int>(Infections.Select(x => x.DeathNumber))));

            Series = new ReactivePropertySlim<SeriesCollection>(new SeriesCollection
            {
                new LineSeries
                {
                    Title = models.FirstOrDefault(x => x.Title.Value ==  "patient").Title.Value,
                    Values = models.FirstOrDefault(x => x.Title.Value ==  "patient").ChartValues.Value,
                    //Stroke = System.Windows.Media.Brushes.Blue,
                    //Fill = Brushes.Transparent
                },
                new LineSeries
                {
                    Title = models.FirstOrDefault(x => x.Title.Value ==  "death").Title.Value,
                    Values = models.FirstOrDefault(x => x.Title.Value ==  "death").ChartValues.Value,
                },
            });
            //this.RegionManager = regionManager;
            //this.RegionManager.RequestNavigate(RegionNames.DashboardLeftRegion, nameof(InfectionChartView));
            //this.RegionManager.RequestNavigate(RegionNames.DashboardRightRegion, nameof(InfectionTableView));
        }

        

    }
}
