using System;

namespace EasyLOB
{    
    public class ZOperationResultException : Exception
    {
        #region Properties

        private string _stackTrace;

        #endregion Properties

        #region Methods

        public ZOperationResultException(string message, string stackTrace)
            : base(message)
        {
            this._stackTrace = stackTrace;
        }

        public override string StackTrace
        {
            get
            {
                return this._stackTrace;
            }
        }

        #endregion Methods
    }
}