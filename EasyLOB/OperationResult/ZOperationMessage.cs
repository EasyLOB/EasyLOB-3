namespace EasyLOB
{
    /// <summary>
    /// Z Operation Message.
    /// </summary>
    public class ZOperationMessage
    {
        #region Properties

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; }

        #endregion Properties

        #region Methods

        public ZOperationMessage()
        {
            Message = "";
        }

        public ZOperationMessage(string message)
        {
            Message = message ?? "";
        }

        #endregion Methods
    }
}