using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace EasyLOB.Identity.Data
{
    public partial class Role : ZDataBase
    {        
        #region Properties
        
        [ZKey()]
        public virtual string Id { get; set; }
        
        public virtual string Name { get; set; }
        
        public virtual string Discriminator { get; set; }

        #endregion Properties

        #region Collections (PK)

        public virtual IList<UserRole> UserRoles { get; }

        #endregion Collections (PK)

        #region Methods
        
        public Role()
        {            
            UserRoles = new List<UserRole>();
    
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
