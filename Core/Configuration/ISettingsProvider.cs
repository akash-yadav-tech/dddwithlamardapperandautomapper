using System;
using System.Collections.Generic;
using System.Text;

namespace POC.Core.Configuration
{
    public interface ISettingsProvider
    {
        T Get<T>(SettingKeys keys, T defaultValue = default(T));
    }
}
