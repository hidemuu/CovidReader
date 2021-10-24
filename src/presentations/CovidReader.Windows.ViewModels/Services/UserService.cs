using CovidReader.Windows.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.ViewControls.Wpf.Services
{
    public class UserService : IUserService
    {
        public List<User> GetAllUsers()
        {
            var allUsers = new List<User>()
           {
               new User(){Id=1,LoginId="admin",Password="admin"},
               new User(){Id=2,LoginId="test",Password="test"},
           };
            return allUsers;
        }
    }
}
