using CovidReader.ViewControls.Wpf.Models;
using CovidReader.Windows.ViewUtility.Constants;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CovidReader.Windows.ViewModels.Login
{
    public class CreateAccountViewModel : BindableBase, INavigationAware, IConfirmNavigationRequest
    {
        private readonly IRegionManager _regionManager;
        private readonly IDialogService _dialogService;
        private IRegionNavigationJournal _journal;

        private string _registeredLoginId;
        public string RegisteredLoginId
        {
            get { return _registeredLoginId; }
            set { SetProperty(ref _registeredLoginId, value); }
        }

        public bool IsUseRequest { get; set; }

        private DelegateCommand _loginMainContentCommand;
        public DelegateCommand LoginMainContentCommand =>
            _loginMainContentCommand ?? (_loginMainContentCommand = new DelegateCommand(ExecuteLoginMainContentCommand));

        private DelegateCommand _goBackCommand;
        public DelegateCommand GoBackCommand =>
            _goBackCommand ?? (_goBackCommand = new DelegateCommand(ExecuteGoBackCommand));

        private DelegateCommand<object> _verityCommand;
        public DelegateCommand<object> VerityCommand =>
            _verityCommand ?? (_verityCommand = new DelegateCommand<object>(ExecuteVerityCommand));

        void ExecuteGoBackCommand()
        {
            _journal.GoBack();
        }

        void ExecuteLoginMainContentCommand()
        {
            Navigate("LoginMainContent");
        }

        void ExecuteVerityCommand(object parameter)
        {
            if (!VerityRegister(parameter))
            {
                return;
            }
            this.IsUseRequest = true;
            var Title = string.Empty;
            _dialogService.ShowDialog("SuccessDialog", new DialogParameters($"message={"登録成功"}"), null);
            _journal.GoBack();
        }

        public CreateAccountViewModel(IRegionManager regionManager, IDialogService dialogService)
        {
            _regionManager = regionManager;
            _dialogService = dialogService;
        }

        private bool VerityRegister(object parameter)
        {
            if (string.IsNullOrEmpty(this.RegisteredLoginId))
            {
                MessageBox.Show("LoginIdが空白です！");
                return false;
            }
            var passwords = parameter as Dictionary<string, PasswordBox>;
            var password = (passwords["Password"] as PasswordBox).Password;
            var confimPassword = (passwords["ConfirmPassword"] as PasswordBox).Password;
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Passwordが空白です！");
                return false;
            }
            if (string.IsNullOrEmpty(confimPassword))
            {
                MessageBox.Show("ConfirmPassword パスワードを確認して下さい！");
                return false;
            }
            if (password.Trim() != confimPassword.Trim())
            {
                MessageBox.Show("アカウントが一致しません");
                return false;
            }
            Global.AllUsers.Add(new User()
            {
                Id = Global.AllUsers.Max(t => t.Id) + 1,
                LoginId = this.RegisteredLoginId,
                Password = password
            });
            return true;
        }


        private void Navigate(string navigatePath)
        {
            if (navigatePath != null)
                _regionManager.RequestNavigate(RegionNames.LoginRegion, navigatePath);
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _journal = navigationContext.NavigationService.Journal;
        }

        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            if (!string.IsNullOrEmpty(RegisteredLoginId) && this.IsUseRequest)
            {
                _dialogService.ShowDialog("AlertDialog", new DialogParameters($"message={"登録してもいいですか？"}"), r =>
                {
                    if (r.Result == ButtonResult.Yes)
                        navigationContext.Parameters.Add("loginId", RegisteredLoginId);
                });
            }
            continuationCallback(true);
            
        }

    }
}
