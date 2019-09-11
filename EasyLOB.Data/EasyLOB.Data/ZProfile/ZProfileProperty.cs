using System;
using System.Runtime.Serialization;

namespace EasyLOB.Data
{
    [DataContract]
    [Serializable]
    public class ZProfileProperty : IZProfileProperty
    {
        #region Properties

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public bool IsKey { get; set; }

        [DataMember]
        public bool IsIdentity { get; set; }

        //[DataMember]
        //public bool IsRequiredData { get; set; }

        [DataMember]
        public bool IsRequiredView { get; set; }

        [DataMember]
        public bool IsGridVisible { get; set; }

        [DataMember]
        public bool IsGridSearch { get; set; }

        [DataMember]
        public int GridWidth { get; set; }

        [DataMember]
        public bool IsEditVisible { get; set; }

        [DataMember]
        public bool IsEditReadOnly { get; set; }

        [DataMember]
        public string EditCSS { get; set; }

        #endregion Properties

        #region Methods

        public ZProfileProperty()
        {
        }

        #endregion Methods;
    }
}