using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Models.Covid19.MHLW
{
    public class CovidLineItem : CovidDbObject
    {
        public Death Death { get; set; }
        public Hospitalization Hospitalization { get; set; }

    }
}
