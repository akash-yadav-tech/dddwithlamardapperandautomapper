using System;
using System.Collections.Generic;
using System.Text;

namespace POC.Core.Configuration
{
    public class SettingKeys
    {
        private readonly string _value;
        public SettingKeys(string value)
        {
            _value = value;
        }

        public override string ToString()
        {
            return _value;
        }
        
        public static readonly SettingKeys WelcomeMessage = new SettingKeys("Messages:WelcomeMessage");
        public static readonly SettingKeys LogLevel = new SettingKeys("AppLogging:LogLevel");
        public static readonly SettingKeys LogOutPutTemplate = new SettingKeys("AppLogging:OutPutTemplate");
        public static readonly SettingKeys LogPath = new SettingKeys("AppLogging:PathFormat");
        public static readonly SettingKeys ConnectionString = new SettingKeys("DataBase:ConnectionString");
    }
}
