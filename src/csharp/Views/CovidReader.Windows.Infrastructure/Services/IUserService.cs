﻿using CovidReader.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Windows.Infrastructure.Services
{
    public interface IUserService
    {
        List<User> GetAllUsers();
    }
}
