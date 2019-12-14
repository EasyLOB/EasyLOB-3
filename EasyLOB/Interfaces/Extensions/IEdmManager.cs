using System;

namespace EasyLOB
{
    /// <summary>
    /// IEdmManager.
    /// </summary>
    public interface IEdmManager : IDisposable
    {
        #region Properties

        /// <summary>
        /// EDM root directory.
        /// </summary>
        string RootDirectory { get; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Delete file.
        /// </summary>
        /// <param name="key">File key</param>
        /// <param name="fileType">File type</param>
        /// <returns>Ok ?</returns>
        bool DeleteFile(int key, ZFileTypes fileType);

        /// <summary>
        /// Delete file.
        /// </summary>
        /// <param name="entityName">File entity name</param>
        /// <param name="key">File key</param>
        /// <param name="fileType">File type</param>
        /// <returns>Ok ?</returns>
        bool DeleteFile(string entityName, int key, ZFileTypes fileType);

        /// <summary>
        /// Delete file.
        /// </summary>
        /// <param name="edmFilePath">File path, relative to root directory</param>
        /// <returns></returns>
        bool DeleteFile(string edmFilePath);

        /// <summary>
        /// File exists ?
        /// </summary>
        /// <param name="key">File key</param>
        /// <param name="fileType">File type</param>
        /// <returns>Exists ?</returns>
        bool FileExists(int key, ZFileTypes fileType);

        /// <summary>
        /// File exists ?
        /// </summary>
        /// <param name="entityName">File entity name</param>
        /// <param name="key">File key</param>
        /// <param name="fileType">File type</param>
        /// <returns>Exists ?</returns>
        bool FileExists(string entityName, int key, ZFileTypes fileType);

        /// <summary>
        /// File exists ?
        /// </summary>
        /// <param name="edmFilePath">File path, relative to root directory</param>
        /// <returns>Exists ?</returns>
        bool FileExists(string edmFilePath);

        /// <summary>
        /// Get file path.
        /// </summary>
        /// <param name="key">File key</param>
        /// <param name="fileType">File type</param>
        /// <param name="create">Create path if not exists ?</param>
        /// <returns>File path</returns>
        string GetFilePath(int key, ZFileTypes fileType, bool create);

        /// <summary>
        /// Get file path.
        /// </summary>
        /// <param name="entityName">File entity name</param>
        /// <param name="key">File key</param>
        /// <param name="fileType">File type</param>
        /// <param name="create">Create path if not exists ?</param>
        /// <returns>File path</returns>
        string GetFilePath(string entityName, int key, ZFileTypes fileType, bool create);

        /// <summary>
        /// Get file path.
        /// </summary>
        /// <param name="edmFilePath">File path, relative to root directory</param>
        /// <param name="create">Create path if not exists ?</param>
        /// <returns>File path</returns>
        string GetFilePath(string edmFilePath, bool create);

        /// <summary>
        /// Read file.
        /// </summary>
        /// <param name="key">File key</param>
        /// <param name="fileType">File type</param>
        /// <returns>File</returns>
        byte[] ReadFile(int key, ZFileTypes fileType);

        /// <summary>
        /// Read file.
        /// </summary>
        /// <param name="entityName">File entity name</param>
        /// <param name="key">File key</param>
        /// <param name="fileType">File type</param>
        /// <returns>File</returns>
        byte[] ReadFile(string entityName, int key, ZFileTypes fileType);

        /// <summary>
        /// Read file.
        /// </summary>
        /// <param name="edmFilePath">File path, relative to root directory</param>
        /// <returns>File</returns>
        byte[] ReadFile(string edmFilePath);

        /// <summary>
        /// Write file.
        /// </summary>
        /// <param name="key">File key</param>
        /// <param name="fileType">File type</param>
        /// <param name="file">File</param>
        /// <returns>Ok ?</returns>
        bool WriteFile(int key, ZFileTypes fileType, byte[] file);

        /// <summary>
        /// Write file.
        /// </summary>
        /// <param name="key">File key</param>
        /// <param name="fileType">File type</param>
        /// <param name="filePath">File path</param>
        /// <returns>Ok ?</returns>
        bool WriteFile(int key, ZFileTypes fileType, string filePath);

        /// <summary>
        /// Write file.
        /// </summary>
        /// <param name="entityName">File entity name</param>
        /// <param name="key">File key</param>
        /// <param name="fileType">File type</param>
        /// <param name="file">File</param>
        /// <returns>Ok ?</returns>
        bool WriteFile(string entityName, int key, ZFileTypes fileType, byte[] file);

        /// <summary>
        /// Write file.
        /// </summary>
        /// <param name="entityName">File entity name</param>
        /// <param name="key">File key</param>
        /// <param name="fileType">File type</param>
        /// <param name="filePath">File path</param>
        /// <returns>Ok ?</returns>
        bool WriteFile(string entityName, int key, ZFileTypes fileType, string filePath);

        /// <summary>
        /// Write file.
        /// </summary>
        /// <param name="edmFilePath"></param>
        /// <param name="file">File</param>
        /// <returns>Ok ?</returns>
        bool WriteFile(string edmFilePath, byte[] file);

        /// <summary>
        /// Write file.
        /// </summary>
        /// <param name="edmFilePath">File path, relative to root directory</param>
        /// <param name="filePath">File path</param>
        /// <returns>Ok ?</returns>
        bool WriteFile(string edmFilePath, string filePath);

        #endregion Methods
    }
}