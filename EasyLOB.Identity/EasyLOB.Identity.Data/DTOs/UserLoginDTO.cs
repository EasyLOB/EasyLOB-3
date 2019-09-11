using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace EasyLOB.Identity.Data
{
    public partial class UserLoginDTO : ZDTOBase<UserLoginDTO, UserLogin>
    {
        #region Properties
               
        public virtual string LoginProvider { get; set; }
               
        public virtual string ProviderKey { get; set; }
               
        public virtual string UserId { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual string UserLookupText { get; set; } // UserId

        #endregion Associations (FK)

        #region Methods

        public UserLoginDTO()
        {
            OnConstructor();
        }

        public UserLoginDTO(IZDataBase dataModel)
        {
            FromData(dataModel);
        }
        
        #endregion Methods
    }
}
