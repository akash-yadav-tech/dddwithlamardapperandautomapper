using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace POC.Core.Configuration
{
    public class SettingsProvider : ISettingsProvider
    {
        private readonly IConfiguration _configuration;
        public SettingsProvider(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public T Get<T>(SettingKeys keys, T defaultValue = default)
        {
            return _configuration.GetValue(key: keys.ToString(), defaultValue);
        }
    }
}
