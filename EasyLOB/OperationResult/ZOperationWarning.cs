using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

// .NET WebAPI Serialization k_BackingField Nastiness
// http://stackoverflow.com/questions/12334382/net-webapi-serialization-k-backingfield-nastiness

namespace EasyLOB
{
    /// <summary>
    /// Z Operation Warning.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ZOperationWarning
    {
        #region Properties

        /// <summary>
        /// Warning Code.
        /// </summary>
        [DataMember]
        public string WarningCode { get; }

        /// <summary>
        /// Warning Message.
        /// </summary>
        [DataMember]
        public string WarningMessage { get; }

        /// <summary>
        /// Warning members.
        /// </summary>
        [DataMember]
        public List<string> WarningMembers { get; }

        #endregion Properties

        #region Methods

        public ZOperationWarning()
        {
            WarningCode = "";
            WarningMessage = "";
        }

        [JsonConstructor]
        public ZOperationWarning(string warningCode, string warningMessage, List<string> warningMembers = null)
        {
            WarningCode = warningCode ?? "";
            WarningMessage = warningMessage ?? "";
            WarningMembers = warningMembers ?? new List<string>();
        }

        #endregion Methods
    }
}