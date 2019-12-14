using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

// .NET WebAPI Serialization k_BackingField Nastiness
// http://stackoverflow.com/questions/12334382/net-webapi-serialization-k-backingfield-nastiness

namespace EasyLOB
{
    /// <summary>
    /// Z Operation Information.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ZOperationInformation
    {
        #region Properties

        /// <summary>
        /// Information Code.
        /// </summary>
        [DataMember]
        public string InformationCode { get; }

        /// <summary>
        /// Information Message.
        /// </summary>
        [DataMember]
        public string InformationMessage { get; }

        /// <summary>
        /// Information members.
        /// </summary>
        [DataMember]
        public List<string> InformationMembers { get; }

        #endregion Properties

        #region Methods

        public ZOperationInformation()
        {
            InformationCode = "";
            InformationMessage = "";
            InformationMembers = new List<string>();
        }

        [JsonConstructor]
        public ZOperationInformation(string informationCode, string informationMessage, List<string> informationMembers = null)
        {
            InformationCode = informationCode ?? "";
            InformationMessage = informationMessage ?? "";
            InformationMembers = informationMembers ?? new List<string>();
        }

        #endregion Methods
    }
}