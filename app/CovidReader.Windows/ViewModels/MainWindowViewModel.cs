using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CovidReader.Infrastructure.Wpf.Constants;
using CovidReader.Windows.ViewModels.Buttons;
using CovidReader.Windows.Views;
using Prism;
using Prism.Commands;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using Reactive.Bindings;

namespace CovidReader.Windows.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public ObservableCollection<IContentViewModel> Contents { get; } = new ObservableCollection<IContentViewModel>();
        public ObservableCollection<NavigationIconButtonViewModel> NavigationIconButtonsViewModel { get; } = new ObservableCollection<NavigationIconButtonViewModel>();

        public IRegionManager RegionManager { get; }

        public ReactiveCommand LoadingCommand { get; } = new ReactiveCommand();

        public ReactiveCommand ActiveHomeCommand { get; } = new ReactiveCommand();

        public ReactiveCommand ActiveTableCommand { get; } = new ReactiveCommand();

        public ReactiveCommand ActiveChartCommand { get; } = new ReactiveCommand();

        
        
        public MainWindowViewModel(IModuleManager moduleManager, IRegionManager regionManager, IDialogService dialogService)
        {
            RegionManager = regionManager;
            LoadingCommand.Subscribe(_ => RegionManager.RequestNavigate(RegionNames.MainRegion, nameof(HomeView)));
            ActiveHomeCommand.Subscribe(_ => RegionManager.RequestNavigate(RegionNames.MainRegion, nameof(HomeView)));
            ActiveTableCommand.Subscribe(_ => RegionManager.RequestNavigate(RegionNames.MainRegion, nameof(TableView)));
            ActiveChartCommand.Subscribe(_ => RegionManager.RequestNavigate(RegionNames.MainRegion, nameof(ChartView)));
            
        }


        private void NavigationCompelted(NavigationResult result)
        {
            //if (result.Result == true)
            //{
            //    Thread.Sleep(1000);
            //    _dialogService.Show("SuccessDialog", new DialogParameters($"message={"LoginMainContent画面表示成功"}"), null);
            //}
            //else
            //{
            //    _dialogService.Show("WarningDialog", new DialogParameters($"message={"LoginMainContent画面表示失敗"}"), null);
            //}
        }

        

    }
}
