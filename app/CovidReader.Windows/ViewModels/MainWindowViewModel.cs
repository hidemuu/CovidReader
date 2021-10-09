using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
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
using Reactive.Bindings.Extensions;

namespace CovidReader.Windows.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public ObservableCollection<IContentViewModel> Contents { get; } = new ObservableCollection<IContentViewModel>();

        private int _prevTabPage { get; set; } = 0;
        public ReactivePropertySlim<int> TabPage { get; set; } = new ReactivePropertySlim<int>(-1);

        private IRegionManager _regionManager { get; }

        public ReactiveCommand TabChangeCommand { get; } = new ReactiveCommand();
        public ReactiveCommand LoadingCommand { get; } = new ReactiveCommand();
        public ReactiveCommand ActiveHomeCommand { get; } = new ReactiveCommand();
        public ReactiveCommand ActiveTableCommand { get; } = new ReactiveCommand();
        public ReactiveCommand ActiveChartCommand { get; } = new ReactiveCommand();
        public ReactiveCommand ActiveDashboardCommand { get; } = new ReactiveCommand();
        public ReactiveCommand ActiveSettingCommand { get; } = new ReactiveCommand();



        public MainWindowViewModel(IModuleManager moduleManager, IRegionManager regionManager, IDialogService dialogService)
        {
            _regionManager = regionManager;
            LoadingCommand.Subscribe(_ => ActiveHome());
            ActiveHomeCommand.Subscribe(_ => ActiveHome());
            ActiveTableCommand.Subscribe(_ => ActiveTable());
            ActiveChartCommand.Subscribe(_ => ActiveChart());
            ActiveDashboardCommand.Subscribe(_ => ActiveChart());
            ActiveSettingCommand.Subscribe(_ => ActiveChart());
            TabChangeCommand.Subscribe(_ => ChangeTab());

            Contents.Add(new HomeViewModel());
            Contents.Add(new TableViewModel());
            Contents.Add(new ChartViewModel());
            Contents.Add(new DashboardViewModel());
            Contents.Add(new SettingViewModel());

            // 1sスパンで更新する
            var timer = new ReactiveTimer(TimeSpan.FromSeconds(1), new SynchronizationContextScheduler(SynchronizationContext.Current));
            timer.Subscribe(_ =>
            {
                if (_prevTabPage != TabPage.Value) { ChangeTab(); _prevTabPage = TabPage.Value; }
            });
            //timer.AddTo(CompositeDisposable);
            timer.Start();

        }

        private void ActiveHome() => _regionManager.RequestNavigate(RegionNames.MainRegion, nameof(HomeView));
        private void ActiveTable() => _regionManager.RequestNavigate(RegionNames.MainRegion, nameof(TableView));
        private void ActiveChart() => _regionManager.RequestNavigate(RegionNames.MainRegion, nameof(ChartView));
        private void ActiveDashboard() => _regionManager.RequestNavigate(RegionNames.MainRegion, nameof(DashboardView));
        private void ActiveSetting() => _regionManager.RequestNavigate(RegionNames.MainRegion, nameof(SettingView));
        private void ChangeTab() 
        {
            switch (TabPage.Value)
            {
                case 0: ActiveHome(); break;
                case 1: ActiveTable(); break;
                case 2: ActiveChart(); break;
                case 3: ActiveDashboard(); break;
                case 4: ActiveSetting(); break;
            }
        }

    }
}
