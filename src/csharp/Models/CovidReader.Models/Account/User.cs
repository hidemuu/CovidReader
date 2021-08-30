using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Models.Account
{
    public class User
    {
        public int Id { get; set; }

        public string LoginId { get; set; }

        public string Password { get; set; }
    }
}
