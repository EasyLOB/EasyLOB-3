using System;

namespace EasyLOB.Extensions.Mail
{
    public partial class MailManagerMock : IMailManager
    {
        #region Properties

        public string FromName { get; private set; }

        public string FromAddress { get; private set; }

        public string UserName { get; private set; }

        public string Password { get; private set; }

        #endregion Properties

        #region Methods Interface

        public void Clear(string fromName = null,
            string fromAddress = null,
            string userName = null,
            string password = null)
        {
            FromName = fromName;
            FromAddress = fromAddress;
            UserName = userName;
            Password = password;
        }

        public void Mail(string toAddress,
            string subject, string body, bool isHtml = false)
        {
        }

        public void Mail(string toName, string toAddress,
            string subject, string body, bool isHtml = false, string[] fileAttachmentPaths = null)
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