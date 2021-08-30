using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Models.Covid
{
    public class CovidLineItem : CovidDbObject
    {
        public Death Death { get; set; }
        public Hospitalization Hospitalization { get; set; }

    }
}
