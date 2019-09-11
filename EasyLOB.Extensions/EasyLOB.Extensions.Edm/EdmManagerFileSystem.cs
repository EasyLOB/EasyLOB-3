using EasyLOB.Environment;
using EasyLOB.Library;
using System;
using System.IO;

/*

C:\a\b\c.xlsx
    Directory
        a
        b
    File
        c.xlsx
    DirectoryPath
        C:\a
        C:\a\b
    FilePath
        C:\a\b\c.xlsx

C:
    \EDM <= Root Directory
        \Entity1
            000000000 <= Key 0 to 99
            000000100 <= Key 100 to 199
            ...
        \Entity2
            000000000
            000000100
            ...

 */

namespace EasyLOB.Extensions.Edm
{
    public partial class EdmManagerFileSystem : IEdmManager
    {
        #region Properties Interface

        public string RootDirectory { get; }

        #endregion Properties Interface

        #region Methods

        public EdmManagerFileSystem()
        {
            RootDirectory = ConfigurationHelper.AppSettings<string>("EasyLOB.EDM.FileSystem.Directory");

            if (!String.IsNullOrEmpty(MultiTenantHelper.Tenant.Name))
            {
                RootDirectory = Path.Combine(RootDirectory, MultiTenantHelper.Tenant.Name);
            }
        }

        public EdmManagerFileSystem(string rootDirectory)
        {
            RootDirectory = rootDirectory;
        }

        #endregion Methods

        #region Methods Interface

        public bool DeleteFile(int key, ZFileTypes fileType)
        {
            return DeleteFile("", key, fileType);
        }

        public bool DeleteFile(string entityName, int key, ZFileTypes fileType)
        {
            bool result = false;

            string filePath = GetFilePath(entityName, key, fileType, false);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                result = true;
            }

            return result;
        }

        public bool DeleteFile(string edmFilePath)
        {
            bool result = false;

            string filePath = GetFilePath(edmFilePath, false);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                result = true;
            }

            return result;
        }

        public bool FileExists(int key, ZFileTypes fileType)
        {
            return FileExists("", key, fileType);
        }

        public bool FileExists(string entityName, int key, ZFileTypes fileType)
        {
            return File.Exists(GetFilePath(entityName, key, fileType, false));
        }

        public bool FileExists(string edmFilePath)
        {
            return File.Exists(GetFilePath(edmFilePath, false));
        }

        public string GetFilePath(int key, ZFileTypes fileType, bool create)
        {
            return GetFilePath("", key, fileType, create);
        }

        public string GetFilePath(string entityName, int key, ZFileTypes fileType, bool create)
        {
            string filePath = "";
            string extension = LibraryHelper.GetFileExtension(fileType);

            entityName = (entityName == null) ? "" : entityName;
            string entityKey = String.Format("{0:000000000}", (key / 100) * 100);
            string directoryPath = LibraryHelper.AddDirectorySeparator(RootDirectory) +
                ((entityName == "") ? entityName : entityName + "/") +
                entityKey;

            if (!Directory.Exists(directoryPath) && create)
            {
                Directory.CreateDirectory(directoryPath);
            }

            if (Directory.Exists(directoryPath))
            {
                filePath = directoryPath + "/" + String.Format("{0:000000000}", key) + extension;
            }

            return filePath;
        }

        public string GetFilePath(string edmFilePath, bool create)
        {
            string filePath = "";

            string directoryPath = Path.GetDirectoryName(LibraryHelper.AddDirectorySeparator(RootDirectory) + edmFilePath);
            if (!Directory.Exists(directoryPath) && create)
            {
                Directory.CreateDirectory(directoryPath);
            }

            if (Directory.Exists(directoryPath))
            {
                filePath = LibraryHelper.AddDirectorySeparator(RootDirectory) + edmFilePath;
            }

            return filePath;
        }

        public byte[] ReadFile(int key, ZFileTypes fileType)
        {
            return ReadFile("", key, fileType);
        }

        public byte[] ReadFile(string entityName, int key, ZFileTypes fileType)
        {
            byte[] file = new byte[0];

            if (FileExists(entityName, key, fileType))
            {
                file = File.ReadAllBytes(GetFilePath(entityName, key, fileType, false));
            }

            return file;
        }

        public byte[] ReadFile(string edmFilePath)
        {
            byte[] file = new byte[0];

            if (FileExists(edmFilePath))
            {
                file = File.ReadAllBytes(GetFilePath(edmFilePath, false));
            }

            return file;
        }

        public bool WriteFile(int key, ZFileTypes fileType, byte[] file)
        {
            return WriteFile("", key, fileType, file);
        }

        public bool WriteFile(int key, ZFileTypes fileType, string filePath)
        {
            return WriteFile("", key, fileType, filePath);
        }

        public bool WriteFile(string entityName, int key, ZFileTypes fileType, byte[] file)
        {
            File.WriteAllBytes(GetFilePath(entityName, key, fileType, true), file);

            return true;
        }

        public bool WriteFile(string entityName, int key, ZFileTypes fileType, string filePath)
        {
            bool result = false;

            if (File.Exists(filePath))
            {
                result = WriteFile(entityName, key, fileType, File.ReadAllBytes(filePath));
            }

            return result;
        }

        public bool WriteFile(string edmFilePath, byte[] file)
        {
            File.WriteAllBytes(GetFilePath(edmFilePath, true), file);

            return true;
        }

        public bool WriteFile(string edmFilePath, string filePath)
        {
            bool result = false;

            if (File.Exists(filePath))
            {
                result = WriteFile(edmFilePath, File.ReadAllBytes(filePath));
            }

            return result;
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