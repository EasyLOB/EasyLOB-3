using System;
using System.Collections.Generic;
using System.IO;

namespace EasyLOB.Environment
{
    public partial class EnvironmentManagerDesktop : IEnvironmentManager
    {
        #region Properties Application

        public string ApplicationDirectory
        {
            get
            {
                string result = "";

                result = AppDomain.CurrentDomain.BaseDirectory;

                return result;
            }
        }

        public bool IsWeb
        {
            get { return false; }
        }

        public string WebPath
        {
            get
            {
                string result = "";

                return result;
            }
        }

        public string WebUrl
        {
            get
            {
                string result = "";

                return result;
            }
        }

        public string WebDomain
        {
            get
            {
                string result = "";

                return result;
            }
        }

        public string WebSubDomain
        {
            get
            {
                string result = "";

                return result;
            }
        }

        #endregion Properties Application

        #region Methods Application

        public string ApplicationPath(string path)
        {
            string result = "";

            result = Path.Combine(ApplicationDirectory, path.Trim('~', '/', '\\'));

            return result;
        }

        #endregion Methods Application

        #region Properties Session

        private Dictionary<string, object> SessionDictionary = new Dictionary<string, object>();

        #endregion Properties Session

        #region Methods Session

        public void SessionAbandon()
        {
        }

        public void SessionClear()
        {
            SessionDictionary.Clear();
        }

        public void SessionClear(string sessionName)
        {
            if (SessionDictionary.ContainsKey(sessionName))
            {
                SessionDictionary.Remove(sessionName);
            }
        }

        public object SessionRead(string sessionName)
        {
            object result = null;

            if (SessionDictionary.ContainsKey(sessionName))
            {
                result = SessionDictionary[sessionName];
            }

            return result;
        }

        public void SessionWrite(string sessionName, object value)
        {
            if (SessionDictionary.ContainsKey(sessionName))
            {
                SessionDictionary[sessionName] = value;
            }
            else
            {
                SessionDictionary.Add(sessionName, value);
            }
        }

        #endregion Methods Session
    }
}