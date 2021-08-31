﻿using CovidReader.Windows.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Windows.Infrastructure.Constants
{
    public static class Global
    {
        private static List<User> _allUsers;
        public static List<User> AllUsers
        {
            get { return _allUsers; }
            set { _allUsers = value; }
        }
    }
}