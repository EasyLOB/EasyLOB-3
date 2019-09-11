using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace EasyLOB.Activity.Data
{
    public partial class ActivityRole : ZDataBase
    {        
        #region Properties
        
        private string _activityId;

        [ZKey()]
        public virtual string ActivityId
        {
            get { return this.Activity == null ? _activityId : this.Activity.Id; }
            set
            {
                _activityId = value;
                Activity = null;
            }
        }
        
        [ZKey()]
        public virtual string RoleName { get; set; }
        
        public virtual string Operations { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual Activity Activity { get; set; } // ActivityId

        #endregion Associations (FK)

        #region Methods
        
        public ActivityRole()
        {
            OnConstructor();
        }

        public override object[] GetId()
        {
            return new object[] { ActivityId, RoleName };
        }

        public override void SetId(object[] ids)
        {
            if (ids != null && ids[0] != null)
            {
                ActivityId = DataHelper.IdToString(ids[0]);
            }
            if (ids != null && ids[1] != null)
            {
                RoleName = DataHelper.IdToString(ids[1]);
            }
        }

        #endregion Methods

        #region Methods NHibernate

        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj is ActivityRole)
            {
                var activityRole = (ActivityRole)obj;
                if (activityRole == null)
                {
                    return false;
                }

                if (ActivityId == activityRole.ActivityId && RoleName == activityRole.RoleName)
                {
                    return true;
                }
            }

            return false;
        }

        public override int GetHashCode()
        {
            return (ActivityId.ToString() + "|" + RoleName.ToString()).GetHashCode();
        }

        #endregion Methods NHibernate
    }
}
