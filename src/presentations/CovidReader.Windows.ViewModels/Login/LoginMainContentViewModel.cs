using CovidReader.Windows.Views;
using CovidReader.Windows.Views.Login;
using CovidReader.Windows.Models.Constants;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CovidReader.Windows.Models;

namespace CovidReader.Windows.ViewModels.Login
{
    public class LoginMainContentViewModel : BindableBase, INavigationAware, IRegionMemberLifetime
    {
        private IRegionNavigationJournal journal;
        private readonly IRegionManager regionManager;
        private readonly IDialogService dialogService;

        private bool _isCanExcute;
        public bool IsCanExcute
        {
            get { return _isCanExcute; }
            set { SetProperty(ref _isCanExcute, value); }
        }

        private User _currentUser = new User();
        public User CurrentUser
        {
            get { return _currentUser; }
            set { SetProperty(ref _currentUser, value); }
        }

        public bool KeepAlive => true;

        private DelegateCommand _createAccountCommand;
        public DelegateCommand CreateAccountCommand =>
            _createAccountCommand ?? (_createAccountCommand = new DelegateCommand(ExecuteCreateAccountCommand));

        private DelegateCommand _goForwardCommand;
        public DelegateCommand GoForwardCommand =>
            _goForwardCommand ?? (_goForwardCommand = new DelegateCommand(ExecuteGoForwardCommand));

        private DelegateCommand<PasswordBox> _loginCommand;
        public DelegateCommand<PasswordBox> LoginCommand =>
            _loginCommand ?? (_loginCommand = new DelegateCommand<PasswordBox>(ExecuteLoginCommand, CanExecuteGoForwardCommand));

        void ExecuteCreateAccountCommand()
        {
            Navigate("CreateAccount");
        }
        void ExecuteLoginCommand(PasswordBox passwordBox)
        {
            if (string.IsNullOrEmpty(this.CurrentUser.LoginId))
            {
                dialogService.Show("WarningDialog", new DialogParameters($"message={"LoginIdを入力して下さい!"}"), null);
                return;
            }
            this.CurrentUser.Password = passwordBox.Password;
            if (string.IsNullOrEmpty(this.CurrentUser.Password))
            {
                dialogService.Show("WarningDialog", new DialogParameters($"message={"Passwordを入力して下さい!"}"), null);
                return;
            }
            else if (Global.AllUsers.Where(t => t.LoginId == this.CurrentUser.LoginId && t.Password == this.CurrentUser.Password).Count() == 0)
            {
                dialogService.Show("WarningDialog", new DialogParameters($"message={"LoginIdかPasswordが一致しません!"}"), null);
                return;
            }
            ShellSwitcher.Switch<LoginWindow, MainWindow>();
        }

        private void ExecuteGoForwardCommand()
        {
            journal.GoForward();
        }

        public LoginMainContentViewModel(IRegionManager regionManager, IDialogService dialogService)
        {
            this.regionManager = regionManager;
            this.dialogService = dialogService;
        }

        private void Navigate(string navigatePath)
        {
            if (navigatePath != null)
                regionManager.RequestNavigate(RegionNames.LoginRegion, navigatePath);
        }



        private bool CanExecuteGoForwardCommand(PasswordBox passwordBox)
        {
            this.IsCanExcute = journal != null && journal.CanGoForward;
            return true;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //MessageBox.Show("退出完了 - LoginMainContent");
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            journal = navigationContext.NavigationService.Journal;

            var loginId = navigationContext.Parameters["loginId"] as string;
            if (loginId != null)
            {
                this.CurrentUser = new User() { LoginId = loginId };
            }
            LoginCommand.RaiseCanExecuteChanged();
        }


    }
}
