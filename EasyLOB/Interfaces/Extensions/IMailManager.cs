//using MimeKit;
using System;

namespace EasyLOB
{
    /// <summary>
    /// IMailManager.
    /// </summary>
    public interface IMailManager : IDisposable
    {
        #region Properties

        /// <summary>
        /// From name.
        /// </summary>
        string FromName { get; }

        /// <summary>
        /// From address.
        /// </summary>
        string FromAddress { get; }

        /// <summary>
        /// User name.
        /// </summary>
        string UserName { get; }

        /// <summary>
        ///  Password.
        /// </summary>
        string Password { get; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Clear.
        /// </summary>
        /// <param name="fromName"></param>
        /// <param name="fromAddress"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        void Clear(string fromName = null,
            string fromAddress = null,
            string userName = null,
            string password = null);

        /// <summary>
        /// Mail.
        /// </summary>
        /// <param name="toAddress"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="isHtml"></param>
        void Mail(string toAddress,
            string subject, string body, bool isHtml = false);

        /// <summary>
        /// Mail.
        /// </summary>
        /// <param name="toName"></param>
        /// <param name="toAddress"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="isHtml"></param>
        /// <param name="fileAttachmentPaths"></param>
        void Mail(string toName, string toAddress,
            string subject, string body, bool isHtml = false, string[] fileAttachmentPaths = null);
        /*
        /// <summary>
        /// Mail.
        /// </summary>
        /// <param name="message"></param>
        void Mail(MimeMessage message);

        /// <summary>
        /// Mail.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="ssl"></param>
        void Mail(MimeMessage message,
            string host, int port, string userName, string password, bool ssl);
        */
        #endregion Methods
    }
}