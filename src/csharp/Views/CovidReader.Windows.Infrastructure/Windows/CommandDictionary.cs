using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CovidReader.Windows.Infrastructure.Windows
{
    /// <summary>
    /// Represents a collection of commands keyed by a uri.
    /// </summary>
    public class CommandDictionary
        : Dictionary<Uri, ICommand>
    {
    }
}
