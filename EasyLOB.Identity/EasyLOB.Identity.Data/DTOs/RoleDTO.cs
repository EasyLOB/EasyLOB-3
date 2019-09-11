using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace EasyLOB.Identity.Data
{
    public partial class RoleDTO : ZDTOBase<RoleDTO, Role>
    {
        #region Properties
               
        public virtual string Id { get; set; }
               
        public virtual string Name { get; set; }
               
        public virtual string Discriminator { get; set; }

        #endregion Properties

        #region Methods

        public RoleDTO()
        {
            OnConstructor();
        }

        public RoleDTO(IZDataBase dataModel)
        {
            FromData(dataModel);
        }
        
        #endregion Methods
    }
}
