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

        public ReactiveCommand WeeklyFilterCommand { get; } = new ReactiveCommand();
        public ReactiveCommand MonthlyFilterCommand { get; } = new ReactiveCommand();
        public ReactiveCommand YearlyFilterCommand { get; } = new ReactiveCommand();
        private readonly IEnumerable<Infection> allInfections;
        private readonly IEnumerable<Infection> weeklyInfections;
        private readonly IEnumerable<Infection> monthlyInfections;
        private readonly IEnumerable<Infection> yearlyInfections;
        private readonly ChartValues<int> weeklyCharts = new ChartValues<int>();
        private readonly ChartValues<int> monthlyCharts = new ChartValues<int>();
        private readonly ChartValues<int> yearlyCharts = new ChartValues<int>();
        public ReactivePropertySlim<SeriesCollection> Series { get; private set; }
        public ReactivePropertySlim<ChartValues<int>> ChartValues { get; private set; }
        private ObservableCollection<Infection> Infections { get; set; }
        public ReadOnlyReactiveCollection<InfectionChartModel> Models { get; }
        public InfectionChartViewModel(IRegionManager regionManager, IApiRepository apiRepository)
        {
            this.regionManager = regionManager;
            this.apiRepository = apiRepository;

            var task = this.apiRepository.Infections.GetAsync();
            Task.WaitAll(task);
            allInfections = task.Result;
            var offset = -60;
            weeklyInfections = allInfections.Where(x =>
                DateTime.Now.AddDays(offset - 7) < DateTime.Parse(x.Date) &&
                DateTime.Parse(x.Date) < DateTime.Now.AddDays(offset));
            monthlyInfections = allInfections.Where(x =>
                DateTime.Now.AddDays(offset - 30) < DateTime.Parse(x.Date) &&
                DateTime.Parse(x.Date) < DateTime.Now.AddDays(offset));
            yearlyInfections = allInfections.Where(x =>
                DateTime.Now.AddDays(offset - 365) < DateTime.Parse(x.Date) &&
                DateTime.Parse(x.Date) < DateTime.Now.AddDays(offset));
            Infections = new ObservableCollection<Infection>(weeklyInfections);
            Models = Infections.ToReadOnlyReactiveCollection(c => new InfectionChartModel(c));

            weeklyCharts.AddRange(weeklyInfections.Select(x => x.PatientNumber));
            monthlyCharts.AddRange(monthlyInfections.Select(x => x.PatientNumber));
            yearlyCharts.AddRange(yearlyInfections.Select(x => x.PatientNumber));

            ChartValues = new ReactivePropertySlim<ChartValues<int>>(new ChartValues<int>());
            ChartValues.Value.AddRange(Infections.Select(x => x.PatientNumber));

            Series = new ReactivePropertySlim<SeriesCollection>(new SeriesCollection 
            {
                new LineSeries
                {
                    Values = ChartValues.Value
                }, 
            });
            

            YearlyFilterCommand.Subscribe(_ => FilterDate("y"));
            MonthlyFilterCommand.Subscribe(_ => FilterDate("m"));
            WeeklyFilterCommand.Subscribe(_ => FilterDate("w"));
        }

        private void FilterDate(string filter)
        {
            Infections.Clear();
            switch (filter)
            {
                case "y": Infections.AddRange(yearlyInfections); break;
                case "m": Infections.AddRange(monthlyInfections); break;
                case "w": Infections.AddRange(weeklyInfections); break;
            }

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
