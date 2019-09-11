using IniParser;
using IniParser.Model;
using System;

// Install-Package ini-parser
// *.ini UTF-8-BOM

namespace EasyLOB.Extensions.Ini
{
    public partial class IniManager : IIniManager
    {
        #region Properties IniParser

        private string IniPath { get; }

        private IniData Data { get; }

        private FileIniDataParser Parser { get; }

        #endregion Properties IniParser

        #region Methods

        public IniManager(string iniPath)
        {
            IniPath = iniPath;
            Parser = new FileIniDataParser();
            Data = Parser.ReadFile(iniPath);
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
                }

                disposed = true;
            }
        }

        #endregion Methods IDispose

        #region Methods Interface

        public bool Write(string section, string key, string value)
        {
            bool result = false;

            try
            {
                Data[section][key] = value;
                Parser.WriteFile(IniPath, Data);
                result = true;
            }
            catch { }

            return result;
        }

        public string Read(string section, string key)
        {
            string result = "";

            try
            {
                result = Data[section][key];
            }
            catch { }

            return result;
        }

        public bool DeleteKey(string section, string key)
        {
            bool result = false;

            try
            {
                Data[section].RemoveKey(key);
                Parser.WriteFile(IniPath, Data);
                result = true;
            }
            catch { }

            return result;
        }

        public bool DeleteSection(string section)
        {
            bool result = false;

            try
            {
                Data.Sections.RemoveSection(section);
                Parser.WriteFile(IniPath, Data);
                result = true;
            }
            catch { }

            return result;
        }

        #endregion Methods Interface
    }
}