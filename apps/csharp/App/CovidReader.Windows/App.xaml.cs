using CovidReader.Windows.Infrastructure;
using CovidReader.Windows.Infrastructure.CustomerRegionAdapters;
using CovidReader.Windows.Infrastructure.Services;
using CovidReader.Windows.ViewModels.Dialogs;
using CovidReader.Windows.Views;
using CovidReader.Windows.Views.Dialogs;
using CovidReader.Windows.Views.Login;
using NLog;
using NLog.Config;
using NLog.Targets;
using Prism.Ioc;
using Prism.Modularity;
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
        //private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        //private IList<Task> _tasks = new List<Task>();


        #region ロジック
        //public static void Close()
        //{
        //    //App.Current.MainWindow.Close();
        //}

        //public static void BackupFile(string filePath, string dir)
        //{
        //    var copyTo = Path.Combine(dir, filePath + ".backup");

        //    File.Copy(filePath, copyTo, true);
        //}

        #endregion

        #region イベントハンドラ

        /// <summary>
        /// 起動時イベント
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            //InitializeLogger();

            //_logger.Info("アプリケーションの開始");

            //if (_mutex.WaitOne(0, false) == false)
            //{
            //    // 起動済みのウィンドウをアクティブにする
            //    ShowPrevProcess();

            //    // ここまで
            //    _mutex.Close();
            //    _mutex = null;
            //    Shutdown();

            //    _logger.Info("二重起動のため終了します");
            //    return;
            //}

            //DispatcherUnhandledException += App_DispatcherUnhandledException;

            base.OnStartup(e);


            //var task = RunControllerAsync();
            //_tasks.Add(task);

        }


        /// <summary>
        /// 終了時イベント
        /// </summary>
        /// <param name="e"></param>
        //protected override void OnExit(ExitEventArgs e)
        //{
        //    _logger.Info("アプリケーションの終了");
        //    Task.WhenAll(_tasks);
        //    NLog.LogManager.Shutdown(); // Flush and close down internal threads and timers
        //    base.OnExit(e);
        //}

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var container = PrismIocExtensions.GetContainer(containerRegistry);
            container.AddNewExtension<Interception>()//add Extension Aop
                .RegisterType<IHomeService, HomeService>(new Interceptor<InterfaceInterceptor>(), new InterceptionBehavior<PolicyInjectionBehavior>())
                .RegisterType<IChartService, ChartService>(new Interceptor<InterfaceInterceptor>(), new InterceptionBehavior<PolicyInjectionBehavior>())
                .RegisterType<ITableService, TableService>(new Interceptor<InterfaceInterceptor>(), new InterceptionBehavior<PolicyInjectionBehavior>())
                .RegisterType<IUserService, UserService>(new Interceptor<InterfaceInterceptor>(), new InterceptionBehavior<PolicyInjectionBehavior>());

            ////注册全局命令
            containerRegistry.RegisterSingleton<IApplicationCommands, ApplicationCommands>();
            containerRegistry.RegisterInstance<IFlyoutService>(Container.Resolve<FlyoutService>());

            ////注册导航
            containerRegistry.RegisterForNavigation<LoginMainContent>();
            containerRegistry.RegisterForNavigation<CreateAccount>();
            containerRegistry.RegisterForNavigation<HomeView>();
            containerRegistry.RegisterForNavigation<ChartView>();
            containerRegistry.RegisterForNavigation<TableView>();

            ////注册对话框
            containerRegistry.RegisterDialog<AlertDialog, AlertDialogViewModel>();
            containerRegistry.RegisterDialog<SuccessDialog, SuccessDialogViewModel>();
            containerRegistry.RegisterDialog<WarningDialog, WarningDialogViewModel>();
            containerRegistry.RegisterDialogWindow<DialogWindow>();
        }

        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
            regionAdapterMappings.RegisterMapping(typeof(UniformGrid), Container.Resolve<UniformGridRegionAdapter>());
        }

        //protected override IModuleCatalog CreateModuleCatalog()
        //{
        //    return new DirectoryModuleCatalog() { ModulePath = @".\Modules" };
        //    //return new ConfigurationModuleCatalog();
        //}

        #endregion


        #region 内部ロジック

        /// <summary>
        /// ログ初期設定
        /// </summary>
        private void InitializeLogger()
        {
            var conf = new LoggingConfiguration();
            //ファイル出力定義
            var file = new FileTarget("logfile")
            {
                Encoding = System.Text.Encoding.UTF8,
                Layout = "${longdate} [${threadid:padding=2}] [${uppercase:${level:padding=-5}}] ${callsite}() - ${message}${exception:format=ToString}",
                FileName = "${basedir}/logs/MachineLinkApp_${date:format=yyyyMMdd}.log",
                ArchiveNumbering = ArchiveNumberingMode.Date,
                ArchiveFileName = "${basedir}/logs/MachineLinkApp.log.{#}",
                ArchiveEvery = FileArchivePeriod.None,
                MaxArchiveFiles = 10
            };
            conf.AddTarget(file);

            conf.LoggingRules.Add(new LoggingRule("*", NLog.LogLevel.Debug, file));

            // 設定を反映する
            LogManager.Configuration = conf;
        }

        /// <summary>
        /// 主幹制御 実行処理
        /// </summary>
        private async Task RunControllerAsync()
        {


            await Task.Run(async () =>
            {
                while (true)
                {
                    

                    await Task.Delay(500);
                }
            });

        }

        private void App_DispatcherUnhandledException(
                object sender,
                System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            //            string errorMember = e.Exception.TargetSite.Name;
            //            string errorMessage = e.Exception.Message;
            //            string message = string.Format(
            //        @"例外が{0}で発生。プログラムを継続しますか？
            //エラーメッセージ：{1}",
            //                                      errorMember, errorMessage);
            //            MessageBoxResult result
            //              = MessageBox.Show(message, "DispatcherUnhandledException",
            //                                MessageBoxButton.YesNo, MessageBoxImage.Warning);


            //            if (result == MessageBoxResult.Yes)
            //                e.Handled = true;

            //_logger.Error(e.Exception, "不明なエラーが発生しました");

            //AppController.SnackbarService.ShowMessage(GetExceptionMessage(e.Exception));

            e.Handled = true;
        }

        private string GetExceptionMessage(Exception ex)
        {
            if (ex.InnerException != null)
            {
                return GetExceptionMessage(ex.InnerException);
            }

            return ex.Message;
        }

        #endregion

        #region 別プロセスのウィンドウを前面にだす
        // タスクトレイに収まっている場合に未対応

        public static bool ShowPrevProcess()
        {
            var thisProcess = Process.GetCurrentProcess();
            var hProcesses = Process.GetProcessesByName(thisProcess.ProcessName);
            var iThisProcessId = thisProcess.Id;

            foreach (var hProcess in hProcesses)
            {
                if (hProcess.Id != iThisProcessId)
                {
                    WindowActivator.Activate(hProcess.MainWindowHandle);
                    return true;
                }
            }

            return false;
        }

        #endregion


    }
}
