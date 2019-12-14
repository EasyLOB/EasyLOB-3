using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

// .NET WebAPI Serialization k_BackingField Nastiness
// http://stackoverflow.com/questions/12334382/net-webapi-serialization-k-backingfield-nastiness

namespace EasyLOB
{
    /// <summary>
    /// Z Operation Error.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ZOperationError
    {
        #region Properties

        /// <summary>
        /// Error Code.
        /// </summary>
        [DataMember]
        public string ErrorCode { get; }

        /// <summary>
        /// Error Message.
        /// </summary>
        [DataMember]
        public string ErrorMessage { get; }

        /// <summary>
        /// Error Stack Trace.
        /// </summary>
        [DataMember]
        public string ErrorStackTrace { get; }

        /// <summary>
        /// Exception.
        /// </summary>
        //[DataMember]
        public Exception ErrorException { get; }

        /// <summary>
        /// Error members.
        /// </summary>
        [DataMember]
        public List<string> ErrorMembers { get; }

        #endregion Properties

        #region Methods

        public ZOperationError()
        {
            ErrorCode = "";
            ErrorMessage = "";
            ErrorStackTrace = "";
            ErrorException = null;
            ErrorMembers = new List<string>();
        }

        [JsonConstructor]
        public ZOperationError(string errorCode, string errorMessage, string errorStackTrace = null, Exception errorException = null, List<string> errorMembers = null)
        {
            ErrorCode = errorCode ?? "";
            ErrorMessage = errorMessage ?? "";
            ErrorStackTrace = errorStackTrace ?? "";
            ErrorException = errorException;
            ErrorMembers = errorMembers ?? new List<string>();
        }

        #endregion Methods
    }
}