using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace EasyLOB.Identity.Data
{
    public partial class User : ZDataBase
    {        
        #region Properties
        
        [ZKey()]
        public virtual string Id { get; set; }
        
        public virtual string Email { get; set; }
        
        public virtual bool EmailConfirmed { get; set; }
        
        public virtual string PasswordHash { get; set; }
        
        public virtual string SecurityStamp { get; set; }
        
        public virtual string PhoneNumber { get; set; }
        
        public virtual bool PhoneNumberConfirmed { get; set; }
        
        public virtual bool TwoFactorEnabled { get; set; }
        
        public virtual DateTime? LockoutEndDateUtc { get; set; }
        
        public virtual bool LockoutEnabled { get; set; }
        
        public virtual int AccessFailedCount { get; set; }
        
        public virtual string UserName { get; set; }

        #endregion Properties

        #region Collections (PK)

        public virtual IList<UserClaim> UserClaims { get; }

        public virtual IList<UserLogin> UserLogins { get; }

        public virtual IList<UserRole> UserRoles { get; }

        #endregion Collections (PK)

        #region Methods
        
        public User()
        {
            UserClaims = new List<UserClaim>();
            UserLogins = new List<UserLogin>();
            UserRoles = new List<UserRole>();
    
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
                Id = DataHelper.IdToString(ids[0]);
            }
        }

        #endregion Methods
    }
}
