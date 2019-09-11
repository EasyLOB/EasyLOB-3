using EasyLOB.Library;
using System;

namespace EasyLOB.Extensions.Edm
{
    public partial class EdmManagerMock : IEdmManager
    {
        #region Properties Interface

        public string RootDirectory { get; }

        #endregion Properties Interface

        #region Methods Interface

        public bool DeleteFile(int key, ZFileTypes fileType)
        {
            return true;
        }

        public bool DeleteFile(string entityName, int key, ZFileTypes fileType)
        {
            return true;
        }

        public bool DeleteFile(string edmFilePath)
        {
            return true;
        }

        public bool FileExists(int key, ZFileTypes fileType)
        {
            return true;
        }

        public bool FileExists(string entityName, int key, ZFileTypes fileType)
        {
            return true;
        }

        public bool FileExists(string edmFilePath)
        {
            return true;
        }

        public string GetFilePath(int key, ZFileTypes fileType, bool create)
        {
            return "";
        }

        public string GetFilePath(string entityName, int key, ZFileTypes fileType, bool create)
        {
            return "";
        }

        public string GetFilePath(string edmFilePath, bool create)
        {
            return "";
        }

        public byte[] ReadFile(int key, ZFileTypes fileType)
        {
            return new byte[0] { };
        }

        public byte[] ReadFile(string entityName, int key, ZFileTypes fileType)
        {
            return new byte[0] { };
        }

        public byte[] ReadFile(string edmFilePath)
        {
            return new byte[0] { };
        }

        public bool WriteFile(int key, ZFileTypes fileType, byte[] file)
        {
            return true;
        }

        public bool WriteFile(int key, ZFileTypes fileType, string filePath)
        {
            return true;
        }

        public bool WriteFile(string entityName, int key, ZFileTypes fileType, byte[] file)
        {
            return true;
        }

        public bool WriteFile(string entityName, int key, ZFileTypes fileType, string filePath)
        {
            return true;
        }

        public bool WriteFile(string edmFilePath, byte[] file)
        {
            return true;
        }

        public bool WriteFile(string edmFilePath, string filePath)
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