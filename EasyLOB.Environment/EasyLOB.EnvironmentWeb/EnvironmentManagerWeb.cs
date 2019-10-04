using System;
using System.Web;

namespace EasyLOB.Environment
{
    public class EnvironmentManagerWeb : IEnvironmentManager
    {
        #region Properties Application

        public string ApplicationDirectory
        {
            get
            {
                string result = "";

                result = HttpContext.Current.Server.MapPath("~");

                return result;
            }
        }

        public bool IsWeb
        {
            get { return HttpContext.Current != null; }
        }

        public string WebPath
        {
            get
            {
                string result = "";

                // http://www.easylob.com/controller/action => www.easylob.com/controller/action
                result = HttpContext.Current.Request.ApplicationPath.TrimEnd('/');

                return result;
            }
        }

        public string WebUrl
        {
            get
            {
                string result = "";

                // http://www.easylob.com/controller/action => http://www.easylob.com/controller/action
                result = HttpContext.Current.Request.Url.AbsoluteUri.TrimEnd('/');

                return result;
            }
        }

        public string WebDomain
        {
            get
            {
                string result = "";

                Uri uri = new Uri(WebUrl);
                if (uri.HostNameType == UriHostNameType.Dns)
                {
                    result = uri.Host;
                }

                return result;
            }
        }

        public string WebSubDomain
        {
            get
            {
                string result = "";

                Uri uri = new Uri(WebUrl);
                if (uri.HostNameType == UriHostNameType.Dns)
                {
                    string host = uri.Host;
                    string[] words = host.Split('.');
                    if (words.Length >= 2)
                    {
                        // subdomain.domain
                        // subdomain.domain.com
                        // subdomain.domain.com.br
                        result = words[0];
                    }
                }

                return result;
            }
        }

        #endregion Properties Application

        #region Methods Application

        public string ApplicationPath(string path)
        {
            string result = "";

            // Virtual Path => Physical Path
            //   Directory
            //     ~/EasyLOB-Configuration => C:\GitHub\EasyLOB-Northwind\Northwind.Mvc.AJAX\EasyLOB-Configuration
            //   Path
            //     ~/EasyLOB-Configuration/Menu.json => C:\GitHub\EasyLOB-Northwind\Northwind.Mvc.AJAX\EasyLOB-Configuration\Menu.json
            result = HttpContext.Current.Server.MapPath(path);

            return result;
        }

        #endregion Methods Application

        #region Properties Session

        private System.Web.SessionState.HttpSessionState Session
        {
            get { return HttpContext.Current.Session; }
        }

        #endregion Properties Session

        #region Methods Session

        public void SessionAbandon()
        {
            if (Session != null)
            {
                Session.Abandon();
            }
        }

        public void SessionClear()
        {
            if (Session != null)
            {
                Session.Clear();
            }
        }

        public void SessionClear(string sessionName)
        {
            if (Session != null)
            {
                Session[sessionName] = null;
            }
        }

        public object SessionRead(string sessionName)
        {
            object result = null;

            if (Session != null)
            {
                result = Session[sessionName];
            }

            return result;
        }

        public void SessionWrite(string sessionName, object value)
        {
            if (Session != null)
            {
                Session[sessionName] = value;
            }
        }

        #endregion Methods Session
    }
}
