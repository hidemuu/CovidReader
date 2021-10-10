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
using CovidReader.Infrastructure.Wpf.Services;
using CovidReader.Windows.ViewModels.Buttons;
using CovidReader.Windows.Views;
using MaterialDesignThemes.Wpf;
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
        public ObservableCollection<MainWindowModel> Contents { get; } = new ObservableCollection<MainWindowModel>();
        public ReactivePropertySlim<int> TabPage { get; set; } = new ReactivePropertySlim<int>(-1);
        public ReactivePropertySlim<string> Guidance { get; set; } = new ReactivePropertySlim<string>("");
        public SnackbarMessageQueue SnackMessageQueue { get; } = SnackbarService.Current.MessageQueue;
        private IRegionManager _regionManager { get; }

        public ReactiveCommand TabChangeCommand { get; } = new ReactiveCommand();
        public ReactiveCommand LoadingCommand { get; } = new ReactiveCommand();

        private CompositeDisposable _disposables = new CompositeDisposable();

        public MainWindowViewModel(IRegionManager regionManager, IModuleManager moduleManager,IDialogService dialogService)
        {
            _regionManager = regionManager;

            Contents.Add(new MainWindowModel(0, "Home", "Home", () => _regionManager.RequestNavigate(RegionNames.MainRegion, nameof(HomeView))));
            Contents.Add(new MainWindowModel(1, "Table", "Table", () => _regionManager.RequestNavigate(RegionNames.MainRegion, nameof(TableView))));
            Contents.Add(new MainWindowModel(2, "Chart", "Cog", () => _regionManager.RequestNavigate(RegionNames.MainRegion, nameof(ChartView))));
            Contents.Add(new MainWindowModel(3, "Dashboard", "Cog", () => _regionManager.RequestNavigate(RegionNames.MainRegion, nameof(DashboardView))));
            Contents.Add(new MainWindowModel(4, "Setting", "Cog", () => _regionManager.RequestNavigate(RegionNames.MainRegion, nameof(SettingView))));

            LoadingCommand.Subscribe(_ => Contents.FirstOrDefault(x => x.NavigationIconButtonViewModel.Title == "Home").TabCommand());
            TabChangeCommand.Subscribe(_ => ChangeTab());

            // 1sスパンで更新する
            var timer = new ReactiveTimer(TimeSpan.FromSeconds(1), new SynchronizationContextScheduler(SynchronizationContext.Current));
            timer.Subscribe(_ =>
            {
            
            });
            timer.AddTo(_disposables);
            timer.Start();

        }

        private void ChangeTab() 
        {
            Contents.FirstOrDefault(x => x.Index == TabPage.Value).TabCommand();
        }

        public class MainWindowModel
        {
            public int Index { get; }
            public Action TabCommand { get; }

            public NavigationIconButtonViewModel NavigationIconButtonViewModel { get; }

            public MainWindowModel(int index, string title, string iconkey, Action tabcommand)
            {
                Index = index;
                TabCommand = tabcommand;
                NavigationIconButtonViewModel = new NavigationIconButtonViewModel() { Title = title, IconKey = iconkey };
            }

        }

    }
}
