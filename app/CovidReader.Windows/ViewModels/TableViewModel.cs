using CovidReader.Models.Api;
using CovidReader.Windows.ViewModels.Buttons;
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

namespace CovidReader.Windows.ViewModels
{
    public class TableViewModel : BindableBase, INavigationAware, IRegionMemberLifetime
    {
        public NavigationIconButtonViewModel NavigationIconButtonViewModel =>
            new NavigationIconButtonViewModel { Title = "Table", IconKey = "Table" };

        private CompositeDisposable _disposables = new CompositeDisposable();
        private IRegionNavigationJournal _journal;
        //private readonly IRegionManager _regionManager;

        public bool KeepAlive => true;

        //public ObservableCollection<Infection> Models { get; }
        public ReactiveCollection<Infection> Models { get; }

        public TableViewModel()
        {
            //Models = new ObservableCollection<Infection>();
            Models = new ReactiveCollection<Infection>();
            var task = App.NativeController.Api.Infection.GetAsync();
            Task.WaitAll(task);
            //Models = task.Result.ToReadOnlyReactiveCollection(m => new Infection(m));
            foreach (var item in task.Result)
            {
                
                Models.Add(item);
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
            _journal = navigationContext.NavigationService.Journal;


        }
    }
}
