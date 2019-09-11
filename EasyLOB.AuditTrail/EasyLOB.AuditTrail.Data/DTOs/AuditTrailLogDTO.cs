using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace EasyLOB.AuditTrail.Data
{
    public partial class AuditTrailLogDTO : ZDTOBase<AuditTrailLogDTO, AuditTrailLog>
    {
        #region Properties
               
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

        public AuditTrailLogDTO()
        {
            OnConstructor();
        }

        public AuditTrailLogDTO(IZDataBase dataModel)
        {
            FromData(dataModel);
        }
        
        #endregion Methods
    }
}
