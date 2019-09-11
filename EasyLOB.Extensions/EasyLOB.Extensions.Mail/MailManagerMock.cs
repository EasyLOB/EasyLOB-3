using MimeKit;
using System;

namespace EasyLOB.Extensions.Mail
{
    public partial class MailManagerMock : IMailManager
    {
        #region Properties

        public string FromAddress { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        #endregion Properties

        #region Methods

        public MailManagerMock()
        {
            FromAddress = "";
            UserName = "";
            Password = "";
        }

        #endregion Methods

        #region Methods Interface

        public void Mail(string toAddress,
            string subject, string body, bool isHtml = false)
        {
        }

        public void Mail(string fromName,
            string toName, string toAddress,
            string subject, string body, bool isHtml = false, string[] fileAttachmentPaths = null)
        {
        }

        public void Mail(MimeMessage message)
        {
        }

        public void Mail(MimeMessage message,
            string host, int port, string userName, string password, bool ssl)
        {
        }

        #endregion Methods Interface

        #region Methods IDispose

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                }

                disposed = true;
            }
        }

        #endregion Methods IDispose
    }
}