using System;
using System.Collections.Generic;

namespace EasyLOB.Environment
{
    public class AppMenu
    {
        #region Properties

        public int Id { get; set; }
        public string Text { get; set; }
        public int? ParentId { get; set; }

        public string Url { get; set; }

        #endregion Properties

        #region Methods

        public AppMenu(int id, string text, int? parentId, string url)
        {
            Id = id;
            Text = text;
            ParentId = parentId;
            Url = (String.IsNullOrEmpty(url) ? "" : DIHelper.EnvironmentManager.WebPath + "/" + url).Replace("//", "/"); // Url.Content()
        }

        #endregion Methods
    }

    public class AppMenuJson
    {
        #region Properties

        public string Text { get; set; }

        public string Url { get; set; }

        public string Roles { get; set; }

        public List<AppMenuJson> SubMenus { get; }

        #endregion Properties

        #region Methods

        public AppMenuJson()
        {
            Text = "";
            Url = "";
            Roles = "";
            SubMenus = new List<AppMenuJson>();
        }

        #endregion Methods
    }
}