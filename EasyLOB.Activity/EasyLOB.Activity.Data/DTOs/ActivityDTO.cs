using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace EasyLOB.Activity.Data
{
    public partial class ActivityDTO : ZDTOBase<ActivityDTO, Activity>
    {
        #region Properties
               
        public virtual string Id { get; set; }
               
        public virtual string Name { get; set; }

        #endregion Properties

        #region Methods

        public ActivityDTO()
        {
            OnConstructor();
        }

        public ActivityDTO(IZDataBase dataModel)
        {
            FromData(dataModel);
        }
        
        #endregion Methods
    }
}
