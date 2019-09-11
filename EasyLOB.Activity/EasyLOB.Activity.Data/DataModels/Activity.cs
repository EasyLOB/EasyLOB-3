using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace EasyLOB.Activity.Data
{
    public partial class Activity : ZDataBase
    {        
        #region Properties
        
        [ZKey()]
        public virtual string Id { get; set; }
        
        public virtual string Name { get; set; }

        #endregion Properties

        #region Collections (PK)

        public virtual IList<ActivityRole> ActivityRoles { get; }

        #endregion Collections (PK)

        #region Methods
        
        public Activity()
        {
            ActivityRoles = new List<ActivityRole>();
    
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
