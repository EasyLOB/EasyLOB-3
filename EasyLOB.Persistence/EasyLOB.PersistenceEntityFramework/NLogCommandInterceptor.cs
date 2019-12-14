using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;

// Logging and Intercepting Database Operations
// https://msdn.microsoft.com/en-us/data/dn469464.aspx

namespace EasyLOB.Persistence
{
    public class NLogCommandInterceptor : IDbCommandInterceptor
    {
        #region Properties

        private ILogManager LogManager { get; }

        #endregion Properties

        #region Methods

        public NLogCommandInterceptor(ILogManager logManager)
            : base()
        {
            LogManager = logManager;
        }

        public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            LogIfNonAsync(command, interceptionContext);
        }

        public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            LogIfError(command, interceptionContext);
        }

        public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            LogIfNonAsync(command, interceptionContext);
        }

        public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            LogIfError(command, interceptionContext);
        }

        public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            LogIfNonAsync(command, interceptionContext);
        }

        public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            LogIfError(command, interceptionContext);
        }

        private void LogIfError<TResult>(DbCommand command, DbCommandInterceptionContext<TResult> interceptionContext)
        {
            if (interceptionContext.Exception != null)
            {
                LogManager.Error("Command {0} - Exception {1}", command.CommandText, interceptionContext.Exception);
            }
        }

        private void LogIfNonAsync<TResult>(DbCommand command, DbCommandInterceptionContext<TResult> interceptionContext)
        {
            if (!interceptionContext.IsAsync)
            {
                LogManager.Warning("Non-async Command: {0}", command.CommandText);
            }
        }

        #endregion Methods
    }
}