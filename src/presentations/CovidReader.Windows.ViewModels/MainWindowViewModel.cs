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
using CovidReader.ViewControls.Wpf.Services;
using CovidReader.Windows.ViewModels.Buttons;
using CovidReader.Windows.Views;
using CovidReader.Windows.ViewUtility.Constants;
using MaterialDesignThemes.Wpf;
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
        public ObservableCollection<MainWindowModel> Models { get; } = new ObservableCollection<MainWindowModel>();
        public ReactivePropertySlim<int> TabPage { get; set; } = new ReactivePropertySlim<int>(-1);
        public ReactivePropertySlim<string> Guidance { get; set; } = new ReactivePropertySlim<string>("");
        private IRegionManager regionManager { get; }

        public ReactiveCommand TabChangeCommand { get; } = new ReactiveCommand();
        public ReactiveCommand LoadingCommand { get; } = new ReactiveCommand();

        private CompositeDisposable _disposables = new CompositeDisposable();

        public MainWindowViewModel(IRegionManager regionManager, IModuleManager moduleManager,IDialogService dialogService)
        {
            this.regionManager = regionManager;
            //表示ページコンテンツ登録
            Models.Add(new MainWindowModel(0, "Home", "Home", () => this.regionManager.RequestNavigate(RegionNames.MainRegion, nameof(HomeView))));
            Models.Add(new MainWindowModel(1, "Table", "Table", () => this.regionManager.RequestNavigate(RegionNames.MainRegion, nameof(TableView))));
            Models.Add(new MainWindowModel(2, "Chart", "Cog", () => this.regionManager.RequestNavigate(RegionNames.MainRegion, nameof(ChartView))));
            Models.Add(new MainWindowModel(3, "Dashboard", "Cog", () => this.regionManager.RequestNavigate(RegionNames.MainRegion, nameof(DashboardView))));
            Models.Add(new MainWindowModel(4, "Setting", "Cog", () => this.regionManager.RequestNavigate(RegionNames.MainRegion, nameof(SettingView))));

            //ボタンコマンドをサブスクライブ
            LoadingCommand.Subscribe(_ => Models.FirstOrDefault(x => x.NavigationIconButtonViewModel.Title == "Home").TabCommand());
            TabChangeCommand.Subscribe(_ => ChangeTab());

            // 定期更新スレッド
            var timer = new ReactiveTimer(TimeSpan.FromSeconds(1), new SynchronizationContextScheduler(SynchronizationContext.Current));
            timer.Subscribe(_ =>
            {
            
            });
            timer.AddTo(_disposables);
            timer.Start();

        }

        private void ChangeTab() 
        {
            Models.FirstOrDefault(x => x.Index == TabPage.Value).TabCommand();
        }

        /// <summary>
        /// コンテンツコントロール用モデル
        /// </summary>
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
