namespace EasyLOB.Security
{
    public class AuthorizationManagerMock : IAuthorizationManager
    {
        #region Properties

        public IAuthenticationManager AuthenticationManager
        {
            get { return new AuthenticationManagerMock(); }
        }

        #endregion Properties

        #region Methods

        public virtual void Dispose()
        {
        }

        public ZActivityOperations GetOperations(string activity)
        {
            ZActivityOperations activityOperations = new ZActivityOperations();

            activityOperations.IsIndex = true;
            activityOperations.IsSearch = true;
            activityOperations.IsCreate = true;
            activityOperations.IsRead = true;
            activityOperations.IsUpdate = true;
            activityOperations.IsDelete = true;
            activityOperations.IsExport = true;
            activityOperations.IsExecute = true;

            return activityOperations;
        }

        public bool IsAuthorized(string activity, ZOperations operation)
        {
            return true;
        }

        public bool IsAuthorized(string activity, ZOperations operation, ZOperationResult operationResult)
        {
            return true;
        }

        #endregion Methods

        #region Methods IsOperation

        public bool IsOperation(ZActivityOperations activityOperations, ZOperationResult operationResult)
        {
            return true;
        }

        public bool IsIndex(ZActivityOperations activityOperations, ZOperationResult operationResult)
        {
            return true;
        }

        public bool IsSearch(ZActivityOperations activityOperations, ZOperationResult operationResult)
        {
            return true;
        }

        public bool IsCreate(ZActivityOperations activityOperations, ZOperationResult operationResult)
        {
            return true;
        }

        public bool IsRead(ZActivityOperations activityOperations, ZOperationResult operationResult)
        {
            return true;
        }

        public bool IsUpdate(ZActivityOperations activityOperations, ZOperationResult operationResult)
        {
            return true;
        }

        public bool IsDelete(ZActivityOperations activityOperations, ZOperationResult operationResult)
        {
            return true;
        }

        public bool IsExport(ZActivityOperations activityOperations, ZOperationResult operationResult)
        {
            return true;
        }

        public bool IsExecute(ZActivityOperations activityOperations, ZOperationResult operationResult)
        {
            return true;
        }

        public bool IsDashboard(string domain, string dashboardDirectory, string dashboardName, ZOperationResult operationResult)
        {
            return true;
        }

        public bool IsReport(string domain, string reportDirectory, string reportName, ZOperationResult operationResult)
        {
            return true;
        }

        public bool IsTask(string domain, string task, ZOperationResult operationResult)
        {
            return true;
        }
        #endregion Methods IsOperation

        #region Methods Message

        public string MessageAuthorized(string activity, ZOperations operation)
        {
            return "";
        }

        public string MessageNotAuthorized(string activity, ZOperations operation)
        {
            return "";
        }

        #endregion Methods Message
    }
}