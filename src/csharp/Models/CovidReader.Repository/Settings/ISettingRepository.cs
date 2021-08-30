using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Repository.Settings
{
    public interface ISettingRepository
    {
        IConfigRepository Configs { get; }
    }
}
