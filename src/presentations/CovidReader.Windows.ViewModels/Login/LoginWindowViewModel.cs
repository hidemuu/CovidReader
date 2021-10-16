using CovidReader.ViewControls.Wpf.Services;
using CovidReader.Windows.ViewUtility.Constants;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CovidReader.Windows.ViewModels.Login
{
    public class LoginWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IUserService _userService;
        private readonly IDialogService _dialogService;

        private DelegateCommand _loginLoadingCommand;
        public DelegateCommand LoginLoadingCommand =>
            _loginLoadingCommand ?? (_loginLoadingCommand = new DelegateCommand(ExecuteLoginLoadingCommand));

        void ExecuteLoginLoadingCommand()
        {
            //_regionManager.RequestNavigate(RegionNames.LoginContentRegion, "LoginMainContent");
            IRegion region = _regionManager.Regions[RegionNames.LoginRegion];
            region.RequestNavigate("LoginMainContent", NavigationCompelted);
            Global.AllUsers = _userService.GetAllUsers();
        }

        public async Task TestTask()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(6000);
                Debug.WriteLine("test");
            });

        }

        public LoginWindowViewModel(IRegionManager regionManager, IUserService userService, IDialogService dialogService)
        {
            _regionManager = regionManager;
            _userService = userService;
            _dialogService = dialogService;
        }



        private void NavigationCompelted(NavigationResult result)
        {
            if (result.Result == true)
            {
                Thread.Sleep(1000);
                _dialogService.Show("SuccessDialog", new DialogParameters($"message={"LoginMainContent画面表示成功"}"), null);
            }
            else
            {
                _dialogService.Show("WarningDialog", new DialogParameters($"message={"LoginMainContent画面表示失敗"}"), null);
            }
        }


    }
}
