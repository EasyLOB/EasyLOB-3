using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace EasyLOB.Activity.Data
{
    public partial class ActivityRoleDTO : ZDTOBase<ActivityRoleDTO, ActivityRole>
    {
        #region Properties
               
        public virtual string ActivityId { get; set; }
               
        public virtual string RoleName { get; set; }
               
        public virtual string Operations { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual string ActivityLookupText { get; set; } // ActivityId

        #endregion Associations (FK)

        #region Methods

        public ActivityRoleDTO()
        {
            OnConstructor();
        }

        public ActivityRoleDTO(IZDataBase dataModel)
        {
            FromData(dataModel);
        }
        
        #endregion Methods
    }
}
