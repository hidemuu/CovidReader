﻿using CovidReader.Models.Covid19.MHLW;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidReader.Repository.Covid19.MHLW
{
    /// <summary>
    /// 治癒者数
    /// </summary>
    public interface IRecoveryRepository : ICovid19ItemRepository<Recovery>
    {
        
    }
}
