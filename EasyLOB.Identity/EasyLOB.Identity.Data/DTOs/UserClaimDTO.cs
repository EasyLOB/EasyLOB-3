using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace EasyLOB.Identity.Data
{
    public partial class UserClaimDTO : ZDTOBase<UserClaimDTO, UserClaim>
    {
        #region Properties
               
        public virtual int Id { get; set; }
               
        public virtual string UserId { get; set; }
               
        public virtual string ClaimType { get; set; }
               
        public virtual string ClaimValue { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual string UserLookupText { get; set; } // UserId

        #endregion Associations (FK)

        #region Methods

        public UserClaimDTO()
        {
            OnConstructor();
        }

        public UserClaimDTO(IZDataBase dataModel)
        {
            FromData(dataModel);
        }
        
        #endregion Methods
    }
}
