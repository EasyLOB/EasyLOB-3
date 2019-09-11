using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace EasyLOB.AuditTrail.Data
{
    public partial class AuditTrailConfiguration : ZDataBase
    {        
        #region Properties
        
        [ZKey(true)]
        public virtual int Id { get; set; }
        
        public virtual string Domain { get; set; }
        
        public virtual string Entity { get; set; }
        
        public virtual string LogMode { get; set; }
        
        public virtual string LogOperations { get; set; }

        #endregion Properties

        #region Methods
        
        public AuditTrailConfiguration()
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
