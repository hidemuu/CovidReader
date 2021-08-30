using CovidReader.Models.Api;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Windows.ViewModels
{
    public class TableViewModel
    {
        public ObservableCollection<Virus> Models { get; }

        public TableViewModel()
        {
            Models = new ObservableCollection<Virus>();
        }
    }
}
