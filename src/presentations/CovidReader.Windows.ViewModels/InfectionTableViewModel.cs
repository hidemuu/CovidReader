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

        public ReactiveCommand YearlyFilterCommand { get; } = new ReactiveCommand();
        public ReactiveCommand MonthlyFilterCommand { get; } = new ReactiveCommand();
        public ReactiveCommand WeeklyFilterCommand { get; } = new ReactiveCommand();
        public bool KeepAlive => true;
        private ObservableCollection<Infection> Infections { get; set; }
        public ReadOnlyReactiveCollection<InfectionTableModel> Models { get; }
        public ReactiveProperty<InfectionTableModel> SelectedItem { get; set; }

        public InfectionTableViewModel(IRegionManager regionManager, IApiRepository apiRepository)
        {
            this.regionManager = regionManager;
            this.apiRepository = apiRepository;

            var task = this.apiRepository.Infections.GetAsync();
            Task.WaitAll(task);
            Infections = new ObservableCollection<Infection>(task.Result);
            this.Models = Infections.ToReadOnlyReactiveCollection(c => new InfectionTableModel(c));

            YearlyFilterCommand.Subscribe(_ => FilterDate());
            MonthlyFilterCommand.Subscribe(_ => FilterDate());
            WeeklyFilterCommand.Subscribe(_ => FilterDate());

        }

        private void FilterDate()
        {
            Infections.OrderBy(x => DateTime.Parse(x.Date));
            
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
