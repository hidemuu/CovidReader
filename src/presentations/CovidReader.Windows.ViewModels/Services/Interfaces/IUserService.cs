using CovidReader.ViewControls.Wpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.ViewControls.Wpf.Services
{
    public interface IUserService
    {
        List<User> GetAllUsers();
    }
}
