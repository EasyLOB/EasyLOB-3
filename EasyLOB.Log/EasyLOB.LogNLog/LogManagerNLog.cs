using Newtonsoft.Json;
using NLog;
using System;

// NLog.config | NLog.xsd

// 6 - Fatal
// 5 - Error
// 4 - Warning
// 3 - Info
// 2 - Debug
// 1 - Trace
// 0 - Off

namespace EasyLOB.Log
{
    public partial class LogManagerNLog : ILogManager
    {
        #region Properties

        protected Logger Log { get; }

        #endregion Properties

        #region Methods

        public LogManagerNLog()
        {
            Log = NLog.LogManager.GetLogger("NLog");
        }

        public virtual void Dispose()
        {
        }

        public void Trace(string message, params object[] args)
        {
            if (LogHelper.IsLog)
            {
                Log.Trace(message, args);
            }
        }

        public void Debug(string message, params object[] args)
        {
            if (LogHelper.IsLog)
            {
                Log.Debug(message, args);
            }
        }

        public void Information(string message, params object[] args)
        {
            if (LogHelper.IsLog)
            {
                Log.Info(message, args);
            }
        }

        public void Warning(string message, params object[] args)
        {
            if (LogHelper.IsLog)
            {
                Log.Warn(message, args);
            }
        }

        public void Error(string message, params object[] args)
        {
            if (LogHelper.IsLog)
            {
                Log.Error(message, args);
            }
        }

        public void Fatal(string message, params object[] args)
        {
            if (LogHelper.IsLog)
            {
                Log.Fatal(message, args);
            }
        }

        public void Exception(Exception exception, string message, params object[] args)
        {
            if (LogHelper.IsLog)
            {
                Log.Fatal(exception, message, args);
            }
        }

        public void OperationResult(ZOperationResult operationResult, string header = "", string footer = "")
        {
            string message = operationResult.Message;
            LogEventInfo logEventInfo = new LogEventInfo(LogLevel.Trace, Log.Name, message);

            // data.OperationResultOk:False
            // data.OperationResultOk:True
            //logEventInfo.Properties["X-ELMAHIO-SEARCH-OperationResultOk"] = operationResultLog.Ok.ToString();

            if (operationResult.ErrorException != null)
            {
                logEventInfo.Exception = operationResult.ErrorException;
                logEventInfo.Level = LogLevel.Fatal;
                logEventInfo.Properties["OperationResultStatus"] = "Exception";
            }
            else
            {
                if (operationResult.Error)
                {
                    logEventInfo.Level = LogLevel.Error;
                    logEventInfo.Properties["OperationResultStatus"] = "Error";
                }
                else if (operationResult.Warning)
                {
                    logEventInfo.Level = LogLevel.Warn;
                    logEventInfo.Properties["OperationResultStatus"] = "Warning";
                }
                else
                {
                    logEventInfo.Level = LogLevel.Info;
                    logEventInfo.Properties["OperationResultStatus"] = "Information";
                }
            }

            string log =
                (String.IsNullOrEmpty(header) ? "" : header.Trim() + Environment.NewLine)
                + (String.IsNullOrEmpty(operationResult.Text) ? "" : operationResult.Text.Trim() + Environment.NewLine)
                + (String.IsNullOrEmpty(footer) ? "" : footer.Trim() + Environment.NewLine);
            logEventInfo.Properties["OperationResult"] = log;

            Log.Log(logEventInfo);
        }

        #endregion Methods
    }
}