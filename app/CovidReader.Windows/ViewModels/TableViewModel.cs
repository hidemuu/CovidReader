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
    public class TableViewModel : BindableBase, INavigationAware, IRegionMemberLifetime, IContentViewModel
    {
        public NavigationIconButtonViewModel NavigationIconButtonViewModel =>
            new NavigationIconButtonViewModel { Title = "Table", IconKey = "Table" };

        private CompositeDisposable _disposables = new CompositeDisposable();
        private IRegionNavigationJournal _journal;
        //private readonly IRegionManager _regionManager;

        public bool KeepAlive => true;

        public ReactiveCollection<Infection> Models { get; }
        
        public TableViewModel()
        {
            Models = new ReactiveCollection<Infection>();
            
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
            
            var task = App.NativeController.Api.Infection.GetAsync();
            Task.WaitAll(task);
            foreach (var item in task.Result)
            {
                //Models.Add(item);
                Models.AddOnScheduler(item);
            }

        }
    }
}
