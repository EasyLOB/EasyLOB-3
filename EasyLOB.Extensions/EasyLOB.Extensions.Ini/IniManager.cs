using SharpConfig;
using System;

namespace EasyLOB.Extensions.Ini
{
    public partial class IniManager : IIniManager
    {
        #region Properties

        private string IniPath { get; set; }

        private Configuration Configuration { get; set; }

        #endregion Properties

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

        public void Load(string iniPath)
        {
            IniPath = iniPath;
            Configuration = SharpConfig.Configuration.LoadFromFile(IniPath);
        }

        public void Save()
        {
            Configuration.SaveToFile(IniPath);
        }

        public bool Write(string section, string key, string value)
        {
            bool result = false;

            try
            {
                if (Configuration != null)
                {
                    Configuration[section][key].StringValue = value;
                    result = true;
                }
            }
            catch { }

            return result;
        }

        public string Read(string section, string key)
        {
            string result = "";

            try
            {
                if (Configuration != null)
                {
                    var configurationSection = Configuration[section];
                    result = configurationSection[key].StringValue;
                }
            }
            catch { }

            return result;
        }

        public bool DeleteKey(string section, string key)
        {
            bool result = false;

            try
            {
                if (Configuration != null)
                {
                    var configurationSection = Configuration[section];
                    configurationSection.Remove(key);
                    result = true;
                }
            }
            catch { }

            return result;
        }

        public bool DeleteSection(string section)
        {
            bool result = false;

            try
            {
                if (Configuration != null)
                {
                    Configuration.Remove(section);
                    result = true;
                }
            }
            catch { }

            return result;
        }

        #endregion Methods Interface
    }
}