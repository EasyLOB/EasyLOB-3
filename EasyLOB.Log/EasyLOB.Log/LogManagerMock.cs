using System;

namespace EasyLOB.Log
{
    public partial class LogManagerMock : ILogManager
    {
        #region Methods

        public virtual void Dispose()
        {
        }

        public void Trace(string message, params object[] args)
        {
        }

        public void Debug(string message, params object[] args)
        {
        }

        public void Information(string message, params object[] args)
        {
        }

        public void Warning(string message, params object[] args)
        {
        }

        public void Error(string message, params object[] args)
        {
        }

        public void Fatal(string message, params object[] args)
        {
        }

        public void Exception(Exception exception, string message, params object[] args)
        {
        }

        public void OperationResult(ZOperationResult operationResult, string header = "", string footer = "")
        {
        }

        #endregion Methods
    }
}