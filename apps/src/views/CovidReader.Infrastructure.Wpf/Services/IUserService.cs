using CovidReader.Infrastructure.Wpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Infrastructure.Wpf.Services
{
    public interface IUserService
    {
        List<User> GetAllUsers();
    }
}
