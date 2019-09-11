using EasyLOB.Resources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

// .NET WebAPI Serialization k_BackingField Nastiness
// http://stackoverflow.com/questions/12334382/net-webapi-serialization-k-backingfield-nastiness

namespace EasyLOB
{
    /// <summary>
    /// Z Operation Result.
    /// </summary>
    [DataContract]
    [Serializable]
    public class ZOperationResult
    {
        #region Properties

        /// <summary>
        /// Successfull ?
        /// </summary>
        [DataMember]
        public bool Ok
        {
            get
            {
                return !Error && !Warning;
            }
        }

        /// <summary>
        /// Error ?
        /// </summary>
        [DataMember]
        public bool Error
        {
            get
            {
                return !String.IsNullOrEmpty(ErrorCode) || !String.IsNullOrEmpty(ErrorMessage) || OperationErrors.Count > 0;
            }
        }

        /// <summary>
        /// Warning ?
        /// </summary>
        [DataMember]
        public bool Warning
        {
            get
            {
                return !String.IsNullOrEmpty(WarningCode) || !String.IsNullOrEmpty(WarningMessage) || OperationWarnings.Count > 0;
            }
        }

        /// <summary>
        /// Error ?
        /// </summary>
        [DataMember]
        public bool Information
        {
            get
            {
                return !String.IsNullOrEmpty(InformationCode) || !String.IsNullOrEmpty(InformationMessage);
            }
        }

        /// <summary>
        /// Data.
        /// </summary>
        [DataMember]
        public string Data { get; set; }

        /// <summary>
        /// Error Code.
        /// </summary>
        [DataMember]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Error Message.
        /// </summary>
        [DataMember]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Error Stack Trace.
        /// </summary>
        [DataMember]
        public string ErrorStackTrace { get; }

        /// <summary>
        /// Error Exception.
        /// </summary>
        //[DataMember]
        public Exception ErrorException { get; set; }

        /// <summary>
        /// Exception.
        /// </summary>
        [DataMember]
        public ZOperationResultException Exception
        {
            get
            {
                if (OperationErrors.Count > 0)
                {
                    return new ZOperationResultException(OperationErrors[0].ErrorMessage ?? "", OperationErrors[0].ErrorStackTrace ?? "");
                }
                else
                {
                    return new ZOperationResultException(ErrorMessage ?? "", ErrorStackTrace ?? "");
                }
            }
        }

        /// <summary>
        /// Operation Result Html.
        /// </summary>
        [DataMember]
        public string Html
        {
            get
            {
                string result = "";
                string br = "";
                int button = 1;

                // Error

                string labelError = "<label class=\"label label-danger\">{0}</label>";

                // Error Message

                if (!String.IsNullOrEmpty(ErrorCode) || !String.IsNullOrEmpty(ErrorMessage))
                {
                    string text =
                        ErrorResources.Error + ": " +
                        (!String.IsNullOrEmpty(ErrorCode) ? "[ " + ErrorCode + " ] " : "") +
                        ErrorMessage.Replace("\r\n", "<br />").Replace("\n", "<br />");
                    result += br + String.Format(labelError, text.Trim());
                    br = "<br />";
                }

                // Errors

                foreach (ZOperationError operationError in OperationErrors)
                {
                    string text =
                        ErrorResources.Error + ": " +
                        (!String.IsNullOrEmpty(operationError.ErrorCode) ? "[ " + operationError.ErrorCode + " ] " : "") +
                        operationError.ErrorMessage.Replace("\r\n", "<br />").Replace("\n", "<br />");
                    string members = operationError.ErrorMembers.Count == 0 ? "" : " (" + String.Join(",", operationError.ErrorMembers).Trim() + ")";
                    result += br + String.Format(labelError, text.Trim() + members);
                    br = "<br />";

                    if (!String.IsNullOrEmpty(operationError.ErrorStackTrace))
                    {
                        string buttonId = "button" + button++.ToString();
                        result += "&nbsp;" +
                            String.Format("<button data-toggle=\"collapse\" data-target=\"#{0}\">...</button>", buttonId) +
                            String.Format("<div id=\"{0}\" class=\"collapse\">", buttonId);

                        result += operationError.ErrorStackTrace.Replace("\r\n", "<br />").Replace("\n", "<br />");
                        //if (operationError.ErrorStackTrace.Contains(" at "))
                        //{
                        //    result += operationError.ErrorStackTrace.Replace(" at ", "<br />at ");
                        //}
                        //else
                        //{
                        //    result += operationError.ErrorStackTrace.Replace(" em ", "<br />em ");
                        //}

                        result += "</div>";

                        br = "<br />";
                    }
                }

                // Warning

                string labelWarning = "<label class=\"label label-warning\">{0}</label>";

                // Warning Message

                if (!String.IsNullOrEmpty(WarningCode) || !String.IsNullOrEmpty(WarningMessage))
                {
                    string text =
                        (!String.IsNullOrEmpty(WarningCode) ? "[ " + WarningCode + " ] " : "") +
                        WarningMessage.Replace("\r\n", "<br />").Replace("\n", "<br />");
                    result += br + String.Format(labelWarning, text.Trim());
                    br = "<br />";
                }

                // Warnings

                foreach (ZOperationWarning operationWarning in OperationWarnings)
                {
                    string text =
                        ErrorResources.Warning + ": " +
                        (!String.IsNullOrEmpty(operationWarning.WarningCode) ? "[ " + operationWarning.WarningCode + " ] " : "") +
                        operationWarning.WarningMessage.Replace("\r\n", "<br />").Replace("\n", "<br />");
                    string members = operationWarning.WarningMembers.Count == 0 ? "" : " (" + String.Join(",", operationWarning.WarningMembers).Trim() + ")";
                    result += br + String.Format(labelWarning, text.Trim() + members);
                    br = "<br />";
                }

                // Information

                string labelInformation = "<label class=\"label label-success\">{0}</label>";

                // Information Message

                if (!String.IsNullOrEmpty(InformationCode) || !String.IsNullOrEmpty(InformationMessage))
                {
                    string text =
                        (!String.IsNullOrEmpty(InformationCode) ? "[ " + InformationCode + " ] " : "") +
                        InformationMessage.Replace("\r\n", "<br />").Replace("\n", "<br />");
                    result += br + String.Format(labelInformation, text.Trim());
                    br = "<br />";
                }

                // Informations

                foreach (ZOperationInformation operationInformation in OperationInformations)
                {
                    string text =
                        ErrorResources.Information + ": " +
                        (!String.IsNullOrEmpty(operationInformation.InformationCode) ? "[ " + operationInformation.InformationCode + " ] " : "") +
                        operationInformation.InformationMessage.Replace("\r\n", "<br />").Replace("\n", "<br />");
                    string members = operationInformation.InformationMembers.Count == 0 ? "" : " (" + String.Join(",", operationInformation.InformationMembers).Trim() + ")";
                    result += br + String.Format(labelInformation, text.Trim() + members);
                    br = "<br />";
                }

                // Data

                if (!String.IsNullOrEmpty(Data))
                {
                    string text = "[" + Data + "]";
                    result += br + String.Format(labelInformation, text.Trim());
                    br = "<br />";
                }

                return result;
                //return result + (String.IsNullOrEmpty(result) ? "" : "<br />");
            }
        }

        /// <summary>
        /// Information Code.
        /// </summary>
        [DataMember]
        public string InformationCode { get; set; }

        /// <summary>
        /// Information Message.
        /// </summary>
        [DataMember]
        public string InformationMessage { get; set; }

        /// <summary>
        /// Message.
        /// </summary>
        [DataMember]
        public string Message
        {
            get
            {
                string message = "";

                if (!Ok)
                {
                    if (!String.IsNullOrWhiteSpace(ErrorMessage))
                    {
                        message += ErrorMessage;
                    }
                    else
                    {
                        if (OperationErrors.Count > 0)
                        {
                            message += OperationErrors[0].ErrorMessage;
                        }
                    }

                    if (!String.IsNullOrWhiteSpace(WarningMessage))
                    {
                        message += WarningMessage;
                    }
                    else
                    {
                        if (OperationWarnings.Count > 0)
                        {
                            message += OperationWarnings[0].WarningMessage;
                        }
                    }
                }
                else
                {
                    if (!String.IsNullOrWhiteSpace(InformationMessage))
                    {
                        message += InformationMessage;
                    }
                    else
                    {
                        if (OperationErrors.Count > 0)
                        {
                            message += OperationErrors[0].ErrorMessage;
                        }
                    }
                }

                return message;
            }
        }

        /// <summary>
        /// Operation Result text with "\n".
        /// </summary>
        [DataMember]
        public string Text
        {
            get
            {
                List<string> list = ToList();
                string result = String.Join("\n", list);

                return result;
                //return result + (String.IsNullOrEmpty(result) ? "" : "\n");
            }
        }

        /// <summary>
        /// Warning Code.
        /// </summary>
        [DataMember]
        public string WarningCode { get; set; }

        /// <summary>
        /// Warning Message.
        /// </summary>
        [DataMember]
        public string WarningMessage { get; set; }

        /// <summary>
        /// Operation Errors.
        /// </summary>
        [DataMember]
        public List<ZOperationError> OperationErrors { get; }

        /// <summary>
        /// Operation Informations.
        /// </summary>
        [DataMember]
        public List<ZOperationInformation> OperationInformations { get; }

        /// <summary>
        /// Operation Warnings.
        /// </summary>
        [DataMember]
        public List<ZOperationWarning> OperationWarnings { get; }

        #endregion Properties

        #region Methods

        public ZOperationResult()
        {
            // Ok
            // Error
            // Warning
            // Information
            // Log
            ErrorCode = "";
            ErrorMessage = "";
            ErrorStackTrace = "";
            ErrorException = null;
            InformationCode = "";
            InformationMessage = "";
            WarningCode = "";
            WarningMessage = "";
            OperationErrors = new List<ZOperationError>();
            OperationInformations = new List<ZOperationInformation>();
            OperationWarnings = new List<ZOperationWarning>();
        }

        [JsonConstructor]
        public ZOperationResult(
            string data,
            string errorCode,
            string errorMessage,
            Exception exception,
            string informationCode,
            string informationMessage,
            string warningCode,
            string warningMessage,
            List<ZOperationError> operationErrors,
            List<ZOperationInformation> operationInformations,
            List<ZOperationWarning> operationWarnings)
            : this()
        {
            // Ok
            // Error
            // Warning
            // Information
            Data = data;
            ErrorCode = errorCode ?? "";
            ErrorMessage = errorMessage ?? "";
            ErrorException = exception;
            // Html
            InformationCode = informationCode ?? "";
            InformationMessage = informationMessage ?? "";
            WarningCode = warningCode ?? "";
            WarningMessage = warningMessage ?? "";
            // Text
            OperationErrors = operationErrors ?? OperationErrors;
            OperationInformations = operationInformations ?? OperationInformations;
            OperationWarnings = operationWarnings ?? OperationWarnings;
        }

        ///// <summary>
        ///// Add Operation Error.
        ///// </summary>
        ///// <param name="errorCode">Error code</param>
        ///// <param name="errorMessage">Error message</param>
        //public void AddOperationError(string errorCode, string errorMessage)
        //{
        //    OperationErrors.Add(new ZOperationError(errorCode, errorMessage));
        //}

        /// <summary>
        /// Add Operation Error.
        /// </summary>
        /// <param name="errorCode">Error code</param>
        /// <param name="errorMessage">Error message</param>
        /// <param name="errorStackTrace">Error stack trace</param>
        /// <param name="errorException">Exception</param>
        /// <param name="members">Members</param>
        public void AddOperationError(string errorCode, string errorMessage, string errorStackTrace = null, Exception errorException = null, List<string> members = null)
        {
            OperationErrors.Add(new ZOperationError(errorCode, errorMessage, errorStackTrace, errorException, members));
        }

        /// <summary>
        /// Add Operation Error.
        /// </summary>
        /// <param name="errorCode">Error code</param>
        /// <param name="errorMessage">Error message</param>
        /// <param name="members">Members</param>
        public void AddOperationError(string errorCode, string errorMessage, List<string> members)
        {
            OperationErrors.Add(new ZOperationError(errorCode, errorMessage, null, null, members));
        }

        ///// <summary>
        ///// Add Operation Information.
        ///// </summary>
        ///// <param name="informationCode">Information code</param>
        ///// <param name="informationMessage">Information message</param>
        //public void AddOperationInformation(string informationCode, string informationMessage)
        //{
        //    OperationInformations.Add(new ZOperationInformation(informationCode, informationMessage));
        //}

        /// <summary>
        /// Add Operation Information.
        /// </summary>
        /// <param name="informationCode">Information code</param>
        /// <param name="informationMessage">Information message</param>
        /// <param name="members">Members</param>
        public void AddOperationInformation(string informationCode, string informationMessage, List<string> members = null)
        {
            OperationInformations.Add(new ZOperationInformation(informationCode, informationMessage, members));
        }

        ///// <summary>
        ///// Add Operation Warning.
        ///// </summary>
        ///// <param name="warningCode">Warning code</param>
        ///// <param name="warningMessage">Warning message</param>
        //public void AddOperationWarning(string warningCode, string warningMessage)
        //{
        //    OperationWarnings.Add(new ZOperationWarning(warningCode, warningMessage));
        //}

        /// <summary>
        /// Add Operation Warning.
        /// </summary>
        /// <param name="warningCode">Warning code</param>
        /// <param name="warningMessage">Warning message</param>
        /// <param name="members">Members</param>
        public void AddOperationWarning(string warningCode, string warningMessage, List<string> members = null)
        {
            OperationWarnings.Add(new ZOperationWarning(warningCode, warningMessage, members));
        }

        /// <summary>
        /// Clear.
        /// </summary>
        public void Clear()
        {
            Data = "";
            ErrorCode = "";
            ErrorMessage = "";
            ErrorException = null;
            InformationCode = "";
            InformationMessage = "";
            WarningCode = "";
            WarningMessage = "";
            OperationErrors.Clear();
            OperationInformations.Clear();
            OperationWarnings.Clear();
        }

        /// <summary>
        /// Parse Exception.
        /// </summary>
        /// <param name="exception">Exception</param>
        public void ParseException(Exception exception)
        {
            if (!ParseInnerException(exception))
            {
                AddOperationError("", exception.Message, exception.StackTrace, exception);
            }            
        }

        /// <summary>
        /// Parse Inner Exception.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        private bool ParseInnerException(Exception exception)
        {
            bool result = false;

            if (exception.InnerException != null)
            {
                result = ParseInnerException(exception.InnerException);
                if (!result)
                {
                    AddOperationError("", exception.InnerException.Message, exception.InnerException.StackTrace, exception.InnerException);
                    result = true;
                }                
            }

            return result;
        }

        /// <summary>
        /// Convert ZOperationResult to List[IZOperationMessage]
        /// </summary>
        /// <returns>List</returns>
        public List<ZOperationMessage> ToDataSet()
        {
            List<ZOperationMessage> result = new List<ZOperationMessage>();

            List<string> messages = ToList();
            foreach (string message in messages)
            {
                result.Add(new ZOperationMessage(message));
            }

            return result;
        }

        /// <summary>
        /// Convert ZOperationResult to List[string]
        /// </summary>
        /// <returns>List</returns>
        public List<string> ToList()
        {
            List<string> result = new List<string>();

            // Error Message

            if (!String.IsNullOrEmpty(ErrorCode) || !String.IsNullOrEmpty(ErrorMessage))
            {
                string text =
                    ErrorResources.Error + ": " +
                    (!String.IsNullOrEmpty(ErrorCode) ? "[ " + ErrorCode + " ] " : "") +
                    ErrorMessage;
                result.Add(text.Trim());
            }

            // Errors

            foreach (ZOperationError operationError in OperationErrors)
            {
                string text =
                    ErrorResources.Error + ": " +
                    (!String.IsNullOrEmpty(operationError.ErrorCode) ? "[ " + operationError.ErrorCode + " ] " : "") +
                    operationError.ErrorMessage;
                string members = operationError.ErrorMembers.Count == 0 ? "" : " (" + String.Join(",", operationError.ErrorMembers).Trim() + ")";
                result.Add(text.Trim() + members);

                if (!String.IsNullOrEmpty(operationError.ErrorStackTrace))
                {
                    result.Add(operationError.ErrorStackTrace);
                    //if (operationError.ErrorStackTrace.Contains(" at "))
                    //{
                    //    result.Add(operationError.ErrorStackTrace.Replace(" at ", "\r\nat "));
                    //}
                    //else
                    //{
                    //    result.Add(operationError.ErrorStackTrace.Replace(" em ", "\r\nem "));
                    //}
                }
            }

            // Warning Message

            if (!String.IsNullOrEmpty(WarningCode) || !String.IsNullOrEmpty(WarningMessage))
            {
                string text =
                    ErrorResources.Warning + ": " +
                    (!String.IsNullOrEmpty(WarningCode) ? "[ " + WarningCode + " ] " : "") +
                    WarningMessage;
                result.Add(text.Trim());
            }

            // Warning

            foreach (ZOperationWarning operationWarning in OperationWarnings)
            {
                string text =
                    ErrorResources.Warning + ": " +
                    (!String.IsNullOrEmpty(operationWarning.WarningCode) ? "[ " + operationWarning.WarningCode + " ] " : "") +
                    operationWarning.WarningMessage;
                string members = operationWarning.WarningMembers.Count == 0 ? "" : " (" + String.Join(",", operationWarning.WarningMembers).Trim() + ")";
                result.Add(text.Trim() + members);
            }

            // Information Message

            if (!String.IsNullOrEmpty(InformationCode) || !String.IsNullOrEmpty(InformationMessage))
            {
                string text =
                    ErrorResources.Information + ": " +
                    (!String.IsNullOrEmpty(InformationCode) ? "[ " + InformationCode + " ] " : "") +
                    InformationMessage;
                result.Add(text.Trim());
            }

            // Information

            foreach (ZOperationInformation operationInformation in OperationInformations)
            {
                string text =
                    ErrorResources.Information + ": " +
                    (!String.IsNullOrEmpty(operationInformation.InformationCode) ? "[ " + operationInformation.InformationCode + " ] " : "") +
                    operationInformation.InformationMessage;
                string members = operationInformation.InformationMembers.Count == 0 ? "" : " (" + String.Join(",", operationInformation.InformationMembers).Trim() + ")";
                result.Add(text.Trim() + members);
            }

            return result;
        }

        #endregion Methods
    }
}