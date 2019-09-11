using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace EasyLOB.Identity.Data
{
    public partial class UserClaim : ZDataBase
    {        
        #region Properties
        
        [ZKey(true)]
        public virtual int Id { get; set; }
        
        private string _userId;
        
        public virtual string UserId
        {
            get { return this.User == null ? _userId : this.User.Id; }
            set
            {
                _userId = value;
                User = null;
            }
        }
        
        public virtual string ClaimType { get; set; }
        
        public virtual string ClaimValue { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual User User { get; set; } // UserId

        #endregion Associations (FK)

        #region Methods
        
        public UserClaim()
        {
            OnConstructor();
        }

        public override object[] GetId()
        {
            return new object[] { Id };
        }

        public override void SetId(object[] ids)
        {
            if (ids != null && ids[0] != null)
            {
                Id = DataHelper.IdToInt32(ids[0]);
            }
        }

        #endregion Methods
    }
}
