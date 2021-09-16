using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Models.Api
{
    public class Account : DbObject
    {
        public string LoginId { get; set; }

        public string Password { get; set; }
    }
}
