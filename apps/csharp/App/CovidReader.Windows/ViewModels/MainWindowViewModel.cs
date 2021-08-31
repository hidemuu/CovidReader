using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CovidReader.Windows.Infrastructure.Constants;
using CovidReader.Windows.Views;
using Prism;
using Prism.Commands;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace CovidReader.Windows.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private IModuleManager _moduleManager;
        private readonly IDialogService _dialogService;
        private IRegion _homeRegion;
        private IRegion _chartRegion;
        private IRegion _tableRegion;
        private HomeView _homeView;
        private ChartView _chartView;
        private TableView _tableView;

        public IRegionManager RegionManager { get; }

        private bool _isCanExcute = false;
        public bool IsCanExcute
        {
            get { return _isCanExcute; }
            set { SetProperty(ref _isCanExcute, value); }
        }

        private DelegateCommand _loadingCommand;
        public DelegateCommand LoadingCommand =>
            _loadingCommand ?? (_loadingCommand = new DelegateCommand(ExecuteLoadingCommand));

        private DelegateCommand _activeHomeCommand;
        public DelegateCommand ActiveHomeCommand =>
            _activeHomeCommand ?? (_activeHomeCommand = new DelegateCommand(ExecuteActiveHomeCommand));

        private DelegateCommand _activeTableCommand;
        public DelegateCommand ActiveTableCommand =>
            _activeTableCommand ?? (_activeTableCommand = new DelegateCommand(ExecuteActiveTableCommand));

        private DelegateCommand _activeChartCommand;
        public DelegateCommand ActiveChartCommand =>
            _activeChartCommand ?? (_activeChartCommand = new DelegateCommand(ExecuteActiveChartCommand));

        void ExecuteLoadingCommand()
        {
            _homeRegion = RegionManager.Regions[RegionNames.HomeRegion];
            _homeView = ContainerLocator.Current.Resolve<HomeView>();
            _homeRegion.Add(_homeView);
            _tableRegion = RegionManager.Regions[RegionNames.TableRegion];
            _tableView = ContainerLocator.Current.Resolve<TableView>();
            _tableRegion.Add(_tableView);
            _chartRegion = RegionManager.Regions[RegionNames.ChartRegion];
            _chartView = ContainerLocator.Current.Resolve<ChartView>();
            _chartRegion.Add(_chartView);
            ExecuteActiveHomeCommand();
        }

        void ExecuteLoadModuleCommand()
        {
            _moduleManager.LoadModule("MedicineModule");
            //_medicineMainContentView = (MedicineMainContent)_medicineListRegion.Views.Where(t => t.GetType() == typeof(MedicineMainContent)).FirstOrDefault();
            this.IsCanExcute = true;
        }

        void ExecuteActiveHomeCommand()
        {
            //_homeRegion.RequestNavigate("HomeView", NavigationCompelted);
            _homeRegion.Activate(_homeView);
            _tableRegion.Deactivate(_tableView);
            _chartRegion.Deactivate(_chartView);
        }

        void ExecuteActiveTableCommand()
        {
            //_tableRegion.RequestNavigate("TableView", NavigationCompelted);
            _tableRegion.Activate(_tableView);
            _homeRegion.Deactivate(_homeView);
            _chartRegion.Deactivate(_chartView);
        }

        void ExecuteActiveChartCommand()
        {
            //_chartRegion.RequestNavigate("ChartView", NavigationCompelted);
            _chartRegion.Activate(_chartView);
            _homeRegion.Deactivate(_homeView);
            _tableRegion.Deactivate(_tableView);
        }

        public MainWindowViewModel(IModuleManager moduleManager, IRegionManager regionManager, IDialogService dialogService)
        {
            _moduleManager = moduleManager;
            RegionManager = regionManager;
            _dialogService = dialogService;
            _moduleManager.LoadModuleCompleted += _moduleManager_LoadModuleCompleted;
        }


        private void _moduleManager_LoadModuleCompleted(object sender, LoadModuleCompletedEventArgs e)
        {
            _dialogService.ShowDialog("SuccessDialog", new DialogParameters($"message={e.ModuleInfo.ModuleName + "***"}"), null);
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
