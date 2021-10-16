using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.ViewControls.Wpf
{
    public class ApplicationCommands : IApplicationCommands
    {
        private CompositeCommand _showCommand = new CompositeCommand();

        public CompositeCommand ShowCommand
        {
            get { return _showCommand; }
        }
    }
}
