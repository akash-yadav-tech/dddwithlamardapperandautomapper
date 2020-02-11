using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace POC.Core.Logging
{
    public interface ILoggingService
    {
        void Verbose(string errorMessage);
        void Debug(string errorMessage);
        void Error(string errorMessage);
        void Warning(string warningMessage);
        void Information(string traceMessage);
        void Fatal(string errorMessage);
    }
}
