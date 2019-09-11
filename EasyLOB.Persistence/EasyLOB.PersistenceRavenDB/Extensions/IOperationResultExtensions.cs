using System;
using EasyLOB.Library;

namespace EasyLOB.Persistence
{
    public static partial class IOperationResultExtensions
    {
        public static void ParseExceptionRavenDB(this ZOperationResult operationResult, Exception exception)
        {
            operationResult.ParseException(exception);
        }
    }
}