using CovidReader.UseCases;
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

        private NativeAppController nativeAppController;
        private CompositeDisposable disposables = new CompositeDisposable();
        private IRegionNavigationJournal journal;
        private readonly IRegionManager regionManager;

        public ReactiveCommand RefreshCommand { get; } = new ReactiveCommand();
        public bool KeepAlive => true;

        public ReadOnlyReactiveCollection<TableModel> Contents { get; }
        private ObservableCollection<Infection> infections { get; set; }
        public ReactiveProperty<TableModel> SelectedItem { get; set; }

        public TableViewModel(IRegionManager regionManager, NativeAppController nativeAppController)
        {
            this.regionManager = regionManager;
            this.nativeAppController = nativeAppController;

            var task = this.nativeAppController.Api.Infection.GetAsync();
            Task.WaitAll(task);
            this.infections = new ObservableCollection<Infection>(task.Result);
            this.Contents = this.infections.ToReadOnlyReactiveCollection(c => new TableModel(c));

            //RefreshCommand.Subscribe(_ => Refresh());

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

    public class TableModel
    {
        public ReactivePropertySlim<string> Date { get; } = new ReactivePropertySlim<string>();
        public ReactivePropertySlim<int> Number { get; } = new ReactivePropertySlim<int>();

        public TableModel(Infection model)
        {
            Date.Value = model.Date;
            Number.Value = model.PatientNumber;

        }
    }

}
