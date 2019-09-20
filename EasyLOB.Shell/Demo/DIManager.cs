using EasyLOB.Identity;
using EasyLOB.Identity.Data;
using System;

namespace EasyLOB.Shell
{
    partial class Program
    {
        private static void DIManagerDemo()
        {
            Console.WriteLine("\nUnityManager Demo\n");

            try
            {
                IIdentityUnitOfWork unitOfWork =
                    ManagerHelper.DIManager.GetService<IIdentityUnitOfWork>();
                Console.WriteLine(unitOfWork.ToString());

                IIdentityGenericApplication<User> application =
                    ManagerHelper.DIManager.GetService<IIdentityGenericApplication<User>>();
                Console.WriteLine(application.ToString());

                ZOperationResult operationResult = new ZOperationResult();
                User user = application.Get(operationResult, x => x.UserName.ToLower() == "administrator");
                Console.WriteLine(user.UserName);
            }
            catch (Exception exception)
            {
                WriteException(exception);
            }
        }
    }
}