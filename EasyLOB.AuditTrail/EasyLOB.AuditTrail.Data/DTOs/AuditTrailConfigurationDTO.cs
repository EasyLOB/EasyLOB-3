using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace EasyLOB.AuditTrail.Data
{
    public partial class AuditTrailConfigurationDTO : ZDTOBase<AuditTrailConfigurationDTO, AuditTrailConfiguration>
    {
        #region Properties
               
        public virtual int Id { get; set; }
               
        public virtual string Domain { get; set; }
               
        public virtual string Entity { get; set; }
               
        public virtual string LogMode { get; set; }
               
        public virtual string LogOperations { get; set; }

        #endregion Properties

        #region Methods

        public AuditTrailConfigurationDTO()
        {
            OnConstructor();
        }

        public AuditTrailConfigurationDTO(IZDataBase dataModel)
        {
            FromData(dataModel);
        }
        
        #endregion Methods
    }
}
