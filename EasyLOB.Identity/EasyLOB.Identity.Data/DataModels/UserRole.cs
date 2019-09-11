using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace EasyLOB.Identity.Data
{
    public partial class UserRole : ZDataBase
    {        
        #region Properties
        
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
        
        private string _roleId;
        
        [ZKey()]
        public virtual string RoleId
        {
            get { return this.Role == null ? _roleId : this.Role.Id; }
            set
            {
                _roleId = value;
                Role = null;
            }
        }

        #endregion Properties

        #region Associations (FK)

        public virtual Role Role { get; set; } // RoleId

        public virtual User User { get; set; } // UserId

        #endregion Associations (FK)

        #region Methods
        
        public UserRole()
        {
            OnConstructor();
        }

        public override object[] GetId()
        {
            return new object[] { UserId, RoleId };
        }

        public override void SetId(object[] ids)
        {
            if (ids != null && ids[0] != null)
            {
                UserId = DataHelper.IdToString(ids[0]);
            }
            if (ids != null && ids[1] != null)
            {
                RoleId = DataHelper.IdToString(ids[1]);
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

            if (obj is UserRole)
            {
                var userRole = (UserRole)obj;
                if (userRole == null)
                {
                    return false;
                }

                if (UserId == userRole.UserId && RoleId == userRole.RoleId)
                {
                    return true;
                }
            }

            return false;
        }

        public override int GetHashCode()
        {
            return (UserId.ToString() + "|" + RoleId.ToString()).GetHashCode();
        }

        #endregion Methods NHibernate
    }
}
