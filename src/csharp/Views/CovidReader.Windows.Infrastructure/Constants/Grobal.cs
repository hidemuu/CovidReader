using CovidReader.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Windows.Infrastructure.Constants
{
    public static class Grobal
    {
        private static List<User> _allUsers;
        public static List<User> AllUsers
        {
            get { return _allUsers; }
            set { _allUsers = value; }
        }
    }
}
