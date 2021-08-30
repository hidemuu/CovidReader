using CovidReader.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Windows.Infrastructure.Services
{
    public class UserService : IUserService
    {
        public List<User> GetAllUsers()
        {
            var allUsers = new List<User>()
           {
               new User(){Id=1,LoginId="Admin",Password="Admin123"},
               new User(){Id=1,LoginId="Ryzen",Password="123456"},
               new User(){Id=1,LoginId="Test",Password="Test123"},
           };
            return allUsers;
        }
    }
}
