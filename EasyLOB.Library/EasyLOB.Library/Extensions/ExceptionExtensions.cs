using Newtonsoft.Json;
using System;

namespace EasyLOB.Library
{
    /// <summary>
    /// Exception Extensions.
    /// </summary>
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Get exception message.
        /// </summary>
        /// <param name="exception">Exception</param>
        /// <returns>Message</returns>
        public static string ExceptionMessage(this Exception exception)
        {
            string result = exception.Message;

            if (exception.InnerException != null)
            {
                return result += "\n(" + exception.InnerException.Message + ")";
            }

            return result;
        }

        /// <summary>
        /// Get exception as Operation Result
        /// </summary>
        /// <param name="exception">Exception</param>
        /// <returns>Operation Result</returns>
        public static ZOperationResult OperationResult(this Exception exception)
        {
            ZOperationResult operationResult = null;

            if (exception != null)
            {
                if (!String.IsNullOrEmpty(exception.Message))
                {
                    try
                    {
                        operationResult = JsonConvert.DeserializeObject<ZOperationResult>(exception.Message);
                    }
                    catch { }
                }

                if (operationResult == null && exception.InnerException != null)
                {
                    if (!String.IsNullOrEmpty(exception.InnerException.Message))
                    {
                        try
                        {
                            operationResult = JsonConvert.DeserializeObject<ZOperationResult>(exception.InnerException.Message);
                        }
                        catch { }
                    }
                }
            }

            return operationResult;
        }
    }
}