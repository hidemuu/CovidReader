using CovidReader.Windows.ViewModels.Buttons;
using MaterialDesignColors;
using Prism.Mvvm;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;
using CovidReader.Infrastructure.Wpf.Services;
using System.IO;

namespace CovidReader.Windows.ViewModels
{
    public class SettingViewModel : BindableBase
    {

        public Swatch[] Swatches { get; } = new SwatchesProvider().Swatches.ToArray();

        public ReactivePropertySlim<Swatch> SelectedSwatch { get; }

        public ReactivePropertySlim<string> BackupPath { get; }

        public SettingViewModel()
        {
            // ComboBoxの初期値を設定するにはItemsSourceで利用しているインスタンスの中から指定する必要がある
            SelectedSwatch = new ReactivePropertySlim<Swatch>(Swatches.FirstOrDefault(s => s.Name == ThemeService.CurrentTheme.Name));
            SelectedSwatch.Subscribe(s => ChangeTheme(s));

            var backupPath = "";
            BackupPath = new ReactivePropertySlim<string>(backupPath);
        }

        private void ChangeTheme(Swatch swatch)
        {
            ThemeService.ApplyTheme(swatch);
        }

        public void RegistBackupPath()
        {
            if (Directory.Exists(BackupPath.Value) == false)
            {
                return;
            }
        }

        public void RegistImportURL()
        {

        }


        public void ShutDown()
        {
            
        }

    }
}
