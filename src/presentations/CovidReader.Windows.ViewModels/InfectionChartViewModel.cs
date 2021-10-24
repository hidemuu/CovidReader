using CovidReader.Models.Api;
using CovidReader.Repository.Api;
using CovidReader.Windows.Models;
using LiveCharts;
using LiveCharts.Wpf;
using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CovidReader.Windows.ViewModels
{
    public class InfectionChartViewModel : InfectionViewModelBase
    {

        #region プロパティ
        public ReactivePropertySlim<SeriesCollection> Series { get; private set; }
        private IList<InfectionChartModel> models { get; set; } = new List<InfectionChartModel>();
        
        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="regionManager"></param>
        /// <param name="apiRepository"></param>
        public InfectionChartViewModel(IRegionManager regionManager, IApiRepository apiRepository) : base(regionManager, apiRepository)
        {
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
        }
    }

    public class InfectionChartModel
    {
        public ReactivePropertySlim<string> Title { get; private set; }
        public ReactivePropertySlim<ChartValues<int>> ChartValues { get; private set; }
        //public Brush Stroke { get; private set; }
        //public Brush Fill { get; private set; }

        public InfectionChartModel(string title, ChartValues<int> chartValues)
        {
            Title = new ReactivePropertySlim<string>(title);
            ChartValues = new ReactivePropertySlim<ChartValues<int>>(chartValues);
            
        }

    }

}
