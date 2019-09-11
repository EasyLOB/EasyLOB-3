using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace EasyLOB.Identity.Data
{
    public partial class UserRoleDTO : ZDTOBase<UserRoleDTO, UserRole>
    {
        #region Properties
               
        public virtual string UserId { get; set; }
               
        public virtual string RoleId { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual string RoleLookupText { get; set; } // RoleId

        public virtual string UserLookupText { get; set; } // UserId

        #endregion Associations (FK)

        #region Methods

        public UserRoleDTO()
        {
            OnConstructor();
        }

        public UserRoleDTO(IZDataBase dataModel)
        {
            FromData(dataModel);
        }
        
        #endregion Methods
    }
}
