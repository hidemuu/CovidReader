using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        //private IRegion _chartRegion;
        //private IRegion _tableRegion;
        //private HomeView _homeView;

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

        void ExecuteLoadingCommand()
        {

            _homeRegion = RegionManager.Regions[RegionNames.HomeRegion];
            //_homeView = ContainerLocator.Current.Resolve<HomeView>();
            //_homeRegion.Add(_homeView);

        }

        void ExecuteLoadMedicineModuleCommand()
        {
            _moduleManager.LoadModule("MedicineModule");
            //_medicineMainContentView = (MedicineMainContent)_medicineListRegion.Views.Where(t => t.GetType() == typeof(MedicineMainContent)).FirstOrDefault();
            this.IsCanExcute = true;
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
            _dialogService.ShowDialog("SuccessDialog", new DialogParameters($"message={e.ModuleInfo.ModuleName + "模块被加载了"}"), null);
        }

    }
}
