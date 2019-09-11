using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace EasyLOB.Identity.Data
{
    public partial class UserDTO : ZDTOBase<UserDTO, User>
    {
        #region Properties
               
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

        #region Methods

        public UserDTO()
        {
            OnConstructor();
        }

        public UserDTO(IZDataBase dataModel)
        {
            FromData(dataModel);
        }
        
        #endregion Methods
    }
}
