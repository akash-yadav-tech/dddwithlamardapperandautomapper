using System;
using POC.Core.Logging;
using Serilog;
using Microsoft.Extensions.Configuration;
using Serilog.Sinks.Async;
using System.Threading.Tasks;
using Serilog.Core;
using Serilog.Events;
using POC.Core.Configuration;
using Serilog.Filters;

namespace POC.Infrastructure.Logging.Serilog
{
    public class LoggingService : ILoggingService, IDisposable
    {
        private readonly ISettingsProvider _settingsProvider;
        public LoggingService(ISettingsProvider settingsProvider)
        {
            // Log.Logger = new LoggerConfiguration()
            //     .MinimumLevel.Debug()
            //     .Enrich.FromLogContext()
            //     .CreateLogger();
            // Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();

            // Log.Logger = new LoggerConfiguration()
            // .MinimumLevel.Information()
            // // .WriteTo.File("log-.txt", rollingInterval: RollingInterval.Day)
            // .WriteTo.Async(a => a.RollingFile("logs/log-{Date}.txt",
            //             outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}{Exception}",
            //             levelSwitch: SetLogLevel(this._settingsProvider.Get<string>(SettingKeys.LogLevel))))

            this._settingsProvider = settingsProvider;
            //  https://stackoverflow.com/questions/28292601/serilog-multiple-log-files
            Log.Logger = new LoggerConfiguration()
            .WriteTo.Logger(lc =>
                lc.Filter.ByIncludingOnly(evt => evt.Level == LogEventLevel.Information)
                    .WriteTo.Async(a => a.RollingFile("C:\\Temp\\information_log-{Date}.txt",
                        outputTemplate: this._settingsProvider.Get<string>(SettingKeys.LogOutPutTemplate))))
            .WriteTo.Logger(lc =>
                lc.Filter.ByIncludingOnly(evt => evt.Level == LogEventLevel.Error)
                    .WriteTo.Async(a => a.RollingFile("C:\\Temp\\error_log-{Date}.txt",
                        outputTemplate: this._settingsProvider.Get<string>(SettingKeys.LogOutPutTemplate))))
            .CreateLogger();

            // Log.Logger = new LoggerConfiguration()
            // .WriteTo.Async(a => a.RollingFile(this._settingsProvider.Get<string>(SettingKeys.LogPath),
            //             outputTemplate: this._settingsProvider.Get<string>(SettingKeys.LogOutPutTemplate),
            //             levelSwitch: SetLogLevel(this._settingsProvider.Get<string>(SettingKeys.LogLevel))))
            // .CreateLogger();
        }


        // Verbose	Verbose is the noisiest level, rarely (if ever) enabled for a production app.
        // Debug	Debug is used for internal system events that are not necessarily observable from the outside, but useful when determining how something happened.
        // Information	Information events describe things happening in the system that correspond to its responsibilities and functions. Generally these are the observable actions the system can perform.
        // Warning	When service is degraded, endangered, or may be behaving outside of its expected parameters, Warning level events are used.
        // Error	When functionality is unavailable or expectations broken, an Error event is used.
        // Fatal 

        private LoggingLevelSwitch SetLogLevel(string logLevelKey)
        {
            var appLogginglevelSwitch = new LoggingLevelSwitch();
            switch (logLevelKey)
            {
                case "Verbose":
                    appLogginglevelSwitch.MinimumLevel = LogEventLevel.Verbose;
                    break;
                case "Debug":
                    appLogginglevelSwitch.MinimumLevel = LogEventLevel.Debug;
                    break;
                case "Information":
                    appLogginglevelSwitch.MinimumLevel = LogEventLevel.Information;
                    break;
                case "Warning":
                    appLogginglevelSwitch.MinimumLevel = LogEventLevel.Warning;
                    break;
                case "Error":
                    appLogginglevelSwitch.MinimumLevel = LogEventLevel.Error;
                    break;
                case "Fatal":
                    appLogginglevelSwitch.MinimumLevel = LogEventLevel.Fatal;
                    break;
                default:
                    appLogginglevelSwitch.MinimumLevel = LogEventLevel.Information;
                    break;
            }
            return appLogginglevelSwitch;
        }

        public void Verbose(string errorMessage)
        {
            Log.Verbose(errorMessage);
        }

        public void Debug(string errorMessage)
        {
            Log.Debug(errorMessage);
        }

        public void Error(string errorMessage)
        {
            Log.Error(errorMessage);
        }
        public void Information(string information)
        {
            Log.Information(information);
        }

        public void Warning(string warningMessage)
        {
            Log.Warning(warningMessage);
        }

        public void Fatal(string errorMessage)
        {
            Log.Fatal(errorMessage);
        }

        public void Dispose()
        {
            Log.CloseAndFlush();
        }
    }
}
