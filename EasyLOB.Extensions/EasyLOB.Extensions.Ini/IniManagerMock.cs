using System;

namespace EasyLOB.Extensions.Ini
{
    public partial class IniManagerMock : IIniManager
    {
        #region Methods Interface

        public bool Write(string section, string key, string value)
        {
            return true;
        }

        public string Read(string section, string key)
        {
            return "";
        }

        public bool DeleteKey(string section, string key)
        {
            return true;
        }

        public bool DeleteSection(string section)
        {
            return true;
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