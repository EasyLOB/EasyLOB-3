using System;

namespace EasyLOB
{
    /// <summary>
    /// ILogManager.
    /// </summary>
    public interface ILogManager : IDisposable
    {
        #region Methods

        /// <summary>
        /// Trace.
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="args">Arguments</param>
        void Trace(string message, params object[] args);

        /// <summary>
        /// Debug.
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="args">Arguments</param>
        void Debug(string message, params object[] args);

        /// <summary>
        /// Information.
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="args">Arguments</param>
        void Information(string message, params object[] args);

        /// <summary>
        /// Warning.
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="args">Arguments</param>
        void Warning(string message, params object[] args);

        /// <summary>
        /// Error.
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="args">Arguments</param>
        void Error(string message, params object[] args);

        /// <summary>
        /// Fatal.
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="args">Arguments</param>
        void Fatal(string message, params object[] args);

        /// <summary>
        /// Exception.
        /// </summary>
        /// <param name="exception">Exception</param>
        /// <param name="message">Message</param>
        /// <param name="args">Arguments</param>
        void Exception(Exception exception, string message, params object[] args);

        /// <summary>
        /// OperationResult.
        /// </summary>
        /// <param name="operationResult">Operation result</param>
        /// <param name="header">Header</param>
        /// <param name="footer">Footer</param>
        void OperationResult(ZOperationResult operationResult, string header = null, string footer = null);

        #endregion Methods
    }
}