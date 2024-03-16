using MyErrorLoggerLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyErrorLoggerLib
{
    public sealed class LoggerFactory
    {
        public static IErrorLogger? ErrorLogger;

        public static IErrorLogger GetErrorLogger(string LoggerType)
        {
            if (LoggerType.ToLower().Equals("file"))
                return new ErrorLoggerFile();

            else if (LoggerType.ToLower().Equals("console"))
                return new ErrorLoggerConsole();

            else if (LoggerType.ToLower().Equals("db"))
                return new ErrorLoggerDB();
            return ErrorLogger;
        }
    }
}
