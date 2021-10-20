using CovidReader.UseCases;
using CovidReader.Models.Api;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;
using CovidReader.Repository.Api;

namespace CovidReader.Windows.ViewModels
{
    public class InfectionTableViewModel : BindableBase, INavigationAware, IRegionMemberLifetime
    {

        private IApiRepository apiRepository;
        private CompositeDisposable disposables = new CompositeDisposable();
        private IRegionNavigationJournal journal;
        private readonly IRegionManager regionManager;

        public ReactiveCommand WeeklyFilterCommand { get; } = new ReactiveCommand();
        public ReactiveCommand MonthlyFilterCommand { get; } = new ReactiveCommand();
        public ReactiveCommand YearlyFilterCommand { get; } = new ReactiveCommand();
        
        public bool KeepAlive => true;
        private readonly IEnumerable<Infection> allInfections;
        private readonly IEnumerable<Infection> weeklyInfections;
        private readonly IEnumerable<Infection> monthlyInfections;
        private readonly IEnumerable<Infection> yearlyInfections;
        private ObservableCollection<Infection> Infections { get; set; }
        public ReadOnlyReactiveCollection<InfectionTableModel> Models { get; }
        public ReactiveProperty<InfectionTableModel> SelectedItem { get; set; }

        public InfectionTableViewModel(IRegionManager regionManager, IApiRepository apiRepository)
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
            this.Models = Infections.ToReadOnlyReactiveCollection(c => new InfectionTableModel(c));

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

    public class InfectionTableModel
    {
        public ReactivePropertySlim<string> Date { get; } = new ReactivePropertySlim<string>();
        public ReactivePropertySlim<int> Number { get; } = new ReactivePropertySlim<int>();

        public InfectionTableModel(Infection model)
        {
            Date.Value = model.Date;
            Number.Value = model.PatientNumber;

        }
    }

}
