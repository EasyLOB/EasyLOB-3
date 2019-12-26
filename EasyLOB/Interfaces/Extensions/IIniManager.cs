using System;

namespace EasyLOB
{
    /// <summary>
    /// IIniManager.
    /// </summary>
    public interface IIniManager : IDisposable
    {
        #region Methods

        /// <summary>
        /// Load INI.
        /// </summary>
        /// <param name="iniPath"></param>
        /// <returns>Ok ?</returns>
        void Load(string iniPath);

        /// <summary>
        /// Save INI.
        /// </summary>
        void Save();

        /// <summary>
        /// Write INI.
        /// </summary>
        /// <param name="section">Section</param>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        /// <returns>Ok ?</returns>
        bool Write(string section, string key, string value);

        /// <summary>
        /// Read INI.
        /// </summary>
        /// <param name="section">Section</param>
        /// <param name="key">Key</param>
        /// <returns>Value</returns>
        string Read(string section, string key);

        /// <summary>
        /// Delete INI Key.
        /// </summary>
        /// <param name="section">Section</param>
        /// <param name="key">Key</param>
        /// <returns>Ok ?</returns>
        bool DeleteKey(string section, string key);

        /// <summary>
        /// Delete INI Section.
        /// </summary>
        /// <param name="section">Section</param>
        /// <returns>Ok ?</returns>
        bool DeleteSection(string section);

        #endregion Methods
    }
}