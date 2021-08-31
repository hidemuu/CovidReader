using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Windows.Infrastructure
{
    public interface IApplicationCommands
    {
        public CompositeCommand ShowCommand { get; }
    }
}
