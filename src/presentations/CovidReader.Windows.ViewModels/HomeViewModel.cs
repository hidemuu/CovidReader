﻿using CovidReader.Windows.Views;
using CovidReader.Windows.Views.Login;
using CovidReader.Windows.Models.Constants;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Windows.ViewModels
{
    public class HomeViewModel : BindableBase, INavigationAware, IRegionMemberLifetime
    {

        #region フィールド

        private IRegionNavigationJournal journal;
        private readonly IRegionManager regionManager;

        #endregion

        #region プロパティ

        public bool KeepAlive => true;

        #endregion

        #region コマンド

        public ReactiveCommand LoginCommand { get; } = new ReactiveCommand();

        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="eventAggregator">PubSubパターンでイベントの通知と購読を管理することで、ViewModel間の通信を実現</param>
        public HomeViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            LoginCommand.Subscribe(() => ShellSwitcher.Switch<MainWindow, LoginWindow>());
        }

        #region ナビゲーションメソッド

        /// <summary>
        /// このメソッドの返す値により、画面のインスタンスを使いまわすかどうか制御できる。
        /// true ：インスタンスを使いまわす(画面遷移してもコンストラクタ呼ばれない)
        /// false：インスタンスを使いまわさない(画面遷移するとコンストラクタ呼ばれる)
        /// メソッド実装なし：trueになる
        /// ※コンストラクタは呼ばれないが、Loadedイベントは起きる
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <returns></returns>
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        /// <summary>
        /// この画面から他の画面に遷移する時の処理
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        /// <summary>
        /// 他の画面からこの画面に遷移してきた時の処理
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            journal = navigationContext.NavigationService.Journal;
        }

        #endregion

    }
}
