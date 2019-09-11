using EasyLOB.Library;
using FluentFTP;
using System;
using System.IO;
using System.Net;

// Install-Package FluentFTP

/*

/a/b/c.xlsx
    Directory
        a
        b
    File
        c.xlsx
    DirectoryPath
        /a
        /a/b
    FilePath
        /a/b/c.xlsx

FTP
    /EDM <= Root Directory
        /Entity1
            000000000 <= Key 0 to 99
            000000100 <= Key 100 to 199
            ...
        /Entity2
            000000000
            000000100
            ...

 */

namespace EasyLOB.Extensions.Edm
{
    public partial class EdmManagerFTP : IEdmManager
    {
        #region Properties

        private FtpClient ftpClient;

        #endregion Properties

        #region Properties Interface

        public string RootDirectory { get; }

        #endregion Properties Interface

        #region Methods

        public EdmManagerFTP()
        {
            RootDirectory = ConfigurationHelper.AppSettings<string>("EasyLOB.EDM.FTP.Root");

            ftpClient = new FtpClient();

            ftpClient.Host = ConfigurationHelper.AppSettings<string>("EasyLOB.EDM.FTP.Server");
            ftpClient.Port = ConfigurationHelper.AppSettings<int>("EasyLOB.EDM.FTP.Port");
            ftpClient.Credentials = new NetworkCredential(ConfigurationHelper.AppSettings<string>("EasyLOB.EDM.FTP.User"),
                ConfigurationHelper.AppSettings<string>("EasyLOB.EDM.FTP.Password"));

            ftpClient.Connect();
        }

        public EdmManagerFTP(string rootDirectory)
            : this()
        {
            RootDirectory = rootDirectory;
        }

        protected bool FTPCreateDirectory(string directory)
        {
            ftpClient.CreateDirectory(directory);

            return FTPDirectoryExists(directory);
        }

        protected bool FTPCreateDirectoryPath(string directoryPath)
        {
            string workingDirectory = "";

            try
            {
                workingDirectory = ftpClient.GetWorkingDirectory();
                ftpClient.SetWorkingDirectory("/");

                string currentDirectory = "";
                var separators = new char[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar };
                string[] directories = directoryPath.Split(separators);
                foreach (string directory in directories)
                {
                    if (!ftpClient.DirectoryExists(directory))
                    {
                        ftpClient.CreateDirectory(directory);
                    }

                    currentDirectory += "/" + directory;
                    ftpClient.SetWorkingDirectory(currentDirectory);
                }
            }
            finally
            {
                if (!String.IsNullOrEmpty(workingDirectory))
                {
                    ftpClient.SetWorkingDirectory(workingDirectory);
                }
            }

            return FTPDirectoryExists(directoryPath);
        }

        protected bool FTPDirectoryExists(string directory)
        {
            bool result;
            string workingDirectory = "";

            try
            {
                workingDirectory = ftpClient.GetWorkingDirectory();
                ftpClient.SetWorkingDirectory("/");

                result = ftpClient.DirectoryExists(directory);
            }
            finally
            {
                if (!String.IsNullOrEmpty(workingDirectory))
                {
                    ftpClient.SetWorkingDirectory(workingDirectory);
                }
            }

            return result;
        }

        protected bool FTPFileExists(string filePath)
        {
            bool result;
            string workingDirectory = "";

            try
            {
                workingDirectory = ftpClient.GetWorkingDirectory();
                ftpClient.SetWorkingDirectory("/");

                result = ftpClient.FileExists(filePath);
            }
            finally
            {
                if (!String.IsNullOrEmpty(workingDirectory))
                {
                    ftpClient.SetWorkingDirectory(workingDirectory);
                }
            }

            return result;
        }

        #endregion Methods

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
                    if (ftpClient != null)
                    {
                        ftpClient.Disconnect();
                    }
                }

                disposed = true;
            }
        }

        #endregion Methods IDispose

        #region Methods Interface

        public bool DeleteFile(int key, ZFileTypes fileType)
        {
            return DeleteFile("", key, fileType);
        }

        public bool DeleteFile(string entityName, int key, ZFileTypes fileType)
        {
            bool result;

            string filePath = GetFilePath(entityName, key, fileType, false);
            if (FTPFileExists(filePath))
            {
                ftpClient.DeleteFile(filePath);
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }

        public bool DeleteFile(string edmFilePath)
        {
            bool result;

            string filePath = GetFilePath(edmFilePath, false);
            if (FTPFileExists(filePath))
            {
                ftpClient.DeleteFile(filePath);
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }

        public bool FileExists(int key, ZFileTypes fileType)
        {
            return FileExists("", key, fileType);
        }

        public bool FileExists(string entityName, int key, ZFileTypes fileType)
        {
            return FTPFileExists(GetFilePath(entityName, key, fileType, false));
        }

        public bool FileExists(string edmFilePath)
        {
            return FTPFileExists(GetFilePath(edmFilePath, false));
        }

        public string GetFilePath(int key, ZFileTypes fileType, bool create)
        {
            return GetFilePath("", key, fileType, create);
        }

        public string GetFilePath(string entityName, int key, ZFileTypes fileType, bool create)
        {
            string filePath = "";
            string extension = LibraryHelper.GetFileExtension(fileType);
            string workingDirectory = "";

            try
            {
                workingDirectory = ftpClient.GetWorkingDirectory();

                entityName = (entityName == null) ? "" : entityName;
                string entityKey = String.Format("{0:000000000}", (key / 100) * 100);
                string directoryPath = LibraryHelper.AddDirectorySeparator(RootDirectory) +
                    ((entityName == "") ? entityName : entityName + "/") +
                    entityKey;

                FTPCreateDirectoryPath(directoryPath);

                /*
                ftpClient.SetWorkingDirectory("/");
                if (!FTPDirectoryExists(path) && create) // /root/entityName/entityTree
                {
                    if (FTPCreateDirectory(RootDirectory))
                    {
                        ftpClient.SetWorkingDirectory(RootDirectory);
                        if (FTPCreateDirectory(entityName))
                        {
                            ftpClient.SetWorkingDirectory(entityName);
                            FTPCreateDirectory(entityTree);
                        }
                    }
                }
                 */

                ftpClient.SetWorkingDirectory("/");
                if (FTPDirectoryExists(directoryPath))
                {
                    filePath = directoryPath + "/" + String.Format("{0:000000000}", key) + extension;
                }
            }
            finally
            {
                if (!String.IsNullOrEmpty(workingDirectory))
                {
                    ftpClient.SetWorkingDirectory(workingDirectory);
                }
            }

            return filePath;
        }

        public string GetFilePath(string edmFilePath, bool create)
        {
            string filePath = "";

            string directoryPath = Path.GetDirectoryName(LibraryHelper.AddDirectorySeparator(RootDirectory) + edmFilePath);
            if (!FTPDirectoryExists(directoryPath) && create)
            {
                FTPCreateDirectoryPath(directoryPath);
            }

            if (FTPDirectoryExists(directoryPath))
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

            string path = GetFilePath(entityName, key, fileType, false);
            if (FTPFileExists(path))
            {
                ftpClient.SetWorkingDirectory("/");

                using (var ftpStream = ftpClient.OpenRead(path))
                using (var memoryStream = new MemoryStream((int)ftpStream.Length))
                {
                    int count;
                    byte[] buffer = new byte[8 * 1024];
                    while ((count = ftpStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        memoryStream.Write(buffer, 0, count);
                    }

                    file = memoryStream.ToArray();
                }
            }

            return file;
        }

        public byte[] ReadFile(string filePath)
        {
            return new byte[0] { };
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
            bool result = false;

            ftpClient.SetWorkingDirectory("/");

            using (var memoryStream = new MemoryStream(file))
            using (var ftpStream = ftpClient.OpenWrite(GetFilePath(entityName, key, fileType, true)))
            {
                int count;
                byte[] buffer = new byte[8 * 1024];
                while ((count = memoryStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ftpStream.Write(buffer, 0, count);
                }
            }

            result = true;

            return result;
        }

        public bool WriteFile(string entityName, int key, ZFileTypes fileType, string filePath)
        {
            bool result = false;

            if (File.Exists(filePath))
            {
                ftpClient.SetWorkingDirectory("/");

                using (var fileStream = File.OpenRead(filePath))
                using (var ftpStream = ftpClient.OpenWrite(GetFilePath(entityName, key, fileType, true)))
                {
                    int count;
                    byte[] buffer = new byte[8 * 1024];
                    while ((count = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ftpStream.Write(buffer, 0, count);
                    }
                }

                result = true;
            }

            return result;
        }

        public bool WriteFile(string edmFilePath, byte[] file)
        {
            bool result = false;

            ftpClient.SetWorkingDirectory("/");

            using (var memoryStream = new MemoryStream(file))
            using (var ftpStream = ftpClient.OpenWrite(GetFilePath(edmFilePath, true)))
            {
                int count;
                byte[] buffer = new byte[8 * 1024];
                while ((count = memoryStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ftpStream.Write(buffer, 0, count);
                }
            }

            result = true;

            return result;
        }

        public bool WriteFile(string edmFilePath, string filePath)
        {
            bool result = false;

            if (File.Exists(filePath))
            {
                ftpClient.SetWorkingDirectory("/");

                using (var fileStream = File.OpenRead(filePath))
                using (var ftpStream = ftpClient.OpenWrite(GetFilePath(edmFilePath, true)))
                {
                    int count;
                    byte[] buffer = new byte[8 * 1024];
                    while ((count = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ftpStream.Write(buffer, 0, count);
                    }
                }

                result = true;
            }

            return result;
        }

        #endregion Methods Interface
    }
}