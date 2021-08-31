using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Controllers
{
    public interface IController
    {
        Task UpdateAsync();
        Task AutoRunAsync();
    }
}
