using Microsoft.AspNet.Identity;

namespace EasyLOB.Persistence
{
    public static partial class ZOperationResultExtensions
    {
        public static void ParseIdentityResult(this ZOperationResult operationResult, IdentityResult identityResult)
        {
            if (!identityResult.Succeeded)
            {
                foreach (string error in identityResult.Errors)
                {
                    operationResult.AddOperationError("", error);
                }
            }
        }
    }
}