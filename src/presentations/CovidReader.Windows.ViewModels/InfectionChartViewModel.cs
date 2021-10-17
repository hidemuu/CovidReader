using CovidReader.Models.Api;
using CovidReader.Repository.Api;
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

namespace CovidReader.Windows.ViewModels
{
    public class InfectionChartViewModel : BindableBase, INavigationAware, IRegionMemberLifetime
    {
        
        private IRegionNavigationJournal journal;
        private readonly IRegionManager regionManager;
        private IApiRepository apiRepository;

        public bool KeepAlive => true;

        public SeriesCollection Series { get; set; }
        public ReadOnlyReactiveCollection<InfectionChartModel> Models { get; }
        private ObservableCollection<Infection> infections { get; set; }

        public InfectionChartViewModel(IRegionManager regionManager, IApiRepository apiRepository)
        {
            this.regionManager = regionManager;
            this.apiRepository = apiRepository;

            var task = this.apiRepository.Infections.GetAsync();
            Task.WaitAll(task);
            infections = new ObservableCollection<Infection>(task.Result);
            Models = this.infections.ToReadOnlyReactiveCollection(c => new InfectionChartModel(c));

            var values = new ChartValues<int>();
            foreach (var number in Models.Select(x => x.Number))
            {
                values.Add(number.Value);
            }
            Series = new SeriesCollection
            {
                new LineSeries
                {
                    Values = values
                },
            };
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.journal = navigationContext.NavigationService.Journal;


        }
    }

    public class InfectionChartModel
    {
        
        public ReactivePropertySlim<string> Date { get; } = new ReactivePropertySlim<string>();
        public ReactivePropertySlim<int> Number { get; } = new ReactivePropertySlim<int>();

        public InfectionChartModel(Infection model)
        {
            Date.Value = model.Date;
            Number.Value = model.PatientNumber;

        }
    }
}
