using CovidReader.Repository.Api;
using CovidReader.Repository.Api.Sql;
using CovidReader.Repository.Covid19.MHLW;
using CovidReader.Repository.Covid19.MHLW.Csv;
using CovidReader.Repository.Covid19.MHLW.InMemory;
using CovidReader.Service.Api;
using CovidReader.Service.Covid19;
using CovidReader.UseCases;
using CovidReader.UseCases.Controllers;
using CovidReader.UseCases.Implement;
using CovidReader.ViewControls.Wpf;
using CovidReader.ViewControls.Wpf.CustomerRegionAdapters;
using CovidReader.ViewControls.Wpf.Services;
using CovidReader.Windows.ViewModels;
using CovidReader.Windows.ViewModels.Dialogs;
using CovidReader.Windows.Views;
using CovidReader.Windows.Views.Dialogs;
using CovidReader.Windows.Views.Login;
using NLog;
using NLog.Config;
using NLog.Targets;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using Unity;
using Unity.Interception;
using Unity.Interception.ContainerIntegration;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;
using Unity.Interception.PolicyInjection;

namespace CovidReader.Windows
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        //private Mutex _mutex = new Mutex(false, "CovidReaderApp");


        public App()
        {
            
        }

        #region イベントハンドラ

        /// <summary>
        /// シェル生成
        /// </summary>
        /// <returns></returns>
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>(); //初期表示ビュー
        }

        /// <summary>
        /// コンテナ登録
        /// </summary>
        /// <param name="containerRegistry"></param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //DIコンテナ GetContainerでUnityのコンテナに直接アクセス可能
            var container = containerRegistry.GetContainer();

            //インターフェースとクラスを紐付けて登録
            container.RegisterType<IHomeService, HomeService>();
            container.RegisterType<IChartService, ChartService>();
            container.RegisterType<ITableService, TableService>();
            container.RegisterType<IUserService, UserService>();
            

            //シングルトンとして登録
            containerRegistry.RegisterSingleton<IApplicationCommands, ApplicationCommands>();
            

            //任意のデータインスタンスを登録
            containerRegistry.RegisterInstance<IFlyoutService>(Container.Resolve<FlyoutService>());
            
            containerRegistry.RegisterInstance<IApiRepository>(ApiRepositoryUseCase.UseSqlite());
            containerRegistry.RegisterInstance<IApiMapper>((IApiMapper)ApiRepositoryUseCase.UseSqlite());

            containerRegistry.RegisterInstance<ICovid19Repository>(Covid19RepositoryUseCase.UseInMemory());
            containerRegistry.RegisterInstance<ICovid19Mapper>((ICovid19Mapper)Covid19RepositoryUseCase.UseCsv());

            containerRegistry.RegisterInstance<IApiService>(Container.Resolve<ApiService>());
            containerRegistry.RegisterInstance<ICovid19Service>(Container.Resolve<Covid19Service>());

            containerRegistry.RegisterInstance<IAppController>(Container.Resolve<NativeAppController>());
            //containerRegistry.RegisterInstance<IAppController>(new NativeAppController(ApiServiceUseCase.Create("sql", "sql"), Covid19ServiceUseCase.Create("inmemory", "csv")));

            //Viewの登録
            containerRegistry.RegisterForNavigation<LoginMainContent>();
            containerRegistry.RegisterForNavigation<CreateAccount>();
            containerRegistry.RegisterForNavigation<HomeView>();
            containerRegistry.RegisterForNavigation<InfectionChartView>();
            containerRegistry.RegisterForNavigation<InfectionTableView>();
            containerRegistry.RegisterForNavigation<TreeListView>();
            containerRegistry.RegisterForNavigation<DashboardView>();
            containerRegistry.RegisterForNavigation<SettingView>();

            //Dialogの登録
            containerRegistry.RegisterDialog<AlertDialog, AlertDialogViewModel>();
            containerRegistry.RegisterDialog<SuccessDialog, SuccessDialogViewModel>();
            containerRegistry.RegisterDialog<WarningDialog, WarningDialogViewModel>();
            containerRegistry.RegisterDialogWindow<DialogWindow>();
        }

        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
        }

        /// <summary>
        /// View-ViewModel関連付け
        /// </summary>
        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            ViewModelLocationProvider.Register<MainWindow, MainWindowViewModel>();
            ViewModelLocationProvider.Register<HomeView, HomeViewModel>();
            ViewModelLocationProvider.Register<InfectionChartView, InfectionChartViewModel>();
            ViewModelLocationProvider.Register<InfectionTableView, InfectionTableViewModel>();
            ViewModelLocationProvider.Register<TreeListView, TreeListViewModel>();
            ViewModelLocationProvider.Register<DashboardView, DashboardViewModel>();
            ViewModelLocationProvider.Register<SettingView, SettingViewModel>();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }

        #endregion


        
    }
}
