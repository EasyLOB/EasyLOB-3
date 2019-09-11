using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace EasyLOB.Identity.Data
{
    public partial class UserLogin : ZDataBase
    {        
        #region Properties
        
        [ZKey()]
        public virtual string LoginProvider { get; set; }
        
        [ZKey()]
        public virtual string ProviderKey { get; set; }
        
        private string _userId;
        
        [ZKey()]
        public virtual string UserId
        {
            get { return this.User == null ? _userId : this.User.Id; }
            set
            {
                _userId = value;
                User = null;
            }
        }

        #endregion Properties

        #region Associations (FK)

        public virtual User User { get; set; } // UserId

        #endregion Associations (FK)

        #region Methods
        
        public UserLogin()
        {
            OnConstructor();
        }

        public override object[] GetId()
        {
            return new object[] { LoginProvider, ProviderKey, UserId };
        }

        public override void SetId(object[] ids)
        {
            if (ids != null && ids[0] != null)
            {
                LoginProvider = DataHelper.IdToString(ids[0]);
            }
            if (ids != null && ids[1] != null)
            {
                ProviderKey = DataHelper.IdToString(ids[1]);
            }
            if (ids != null && ids[2] != null)
            {
                UserId = DataHelper.IdToString(ids[2]);
            }
        }

        #endregion Methods

        #region Methods NHibernate

        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj is UserLogin)
            {
                var userLogin = (UserLogin)obj;
                if (userLogin == null)
                {
                    return false;
                }

                if (LoginProvider == userLogin.LoginProvider && ProviderKey == userLogin.ProviderKey && UserId == userLogin.UserId)
                {
                    return true;
                }
            }

            return false;
        }

        public override int GetHashCode()
        {
            return (LoginProvider.ToString() + "|" + ProviderKey.ToString() + "|" + UserId.ToString()).GetHashCode();
        }

        #endregion Methods NHibernate
    }
}
