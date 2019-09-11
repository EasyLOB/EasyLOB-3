using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace EasyLOB.AuditTrail.Data
{
    public partial class AuditTrailLog : ZDataBase
    {        
        #region Properties
        
        [ZKey(true)]
        public virtual int Id { get; set; }
        
        public virtual DateTime? LogDate { get; set; }
        
        public virtual DateTime? LogTime { get; set; }
        
        public virtual string LogUserName { get; set; }
        
        public virtual string LogDomain { get; set; }
        
        public virtual string LogEntity { get; set; }
        
        public virtual string LogOperation { get; set; }
        
        public virtual string LogId { get; set; }
        
        public virtual string LogEntityBefore { get; set; }
        
        public virtual string LogEntityAfter { get; set; }

        #endregion Properties

        #region Methods
        
        public AuditTrailLog()
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
