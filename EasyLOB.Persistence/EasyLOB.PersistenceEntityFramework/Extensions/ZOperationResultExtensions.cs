using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;

namespace EasyLOB.Persistence
{
    public static partial class ZOperationResultExtensions
    {
        public static void ParseExceptionEntityFramework(this ZOperationResult operationResult, Exception exception)
        {
            //System.Data.EntityException
            //    System.Data.EntityCommandCompilationException
            //    System.Data.EntityCommandExecutionException
            //    System.Data.EntitySqlException
            //    System.Data.MappingException
            //    System.Data.MetadataException
            //    System.Data.ProviderIncompatibleException

            //System.Data.DataException
            //    System.Data.Entity.Validation.DbEntityValidationException
            //    System.Data.Entity.Validation.DbUnexpectedValidationException

            if (exception is DbEntityValidationException)
            {
                operationResult.ErrorMessage = exception.Message;

                foreach (DbEntityValidationResult validationResult in (exception as DbEntityValidationException).EntityValidationErrors)
                {
                    foreach (DbValidationError validationError in validationResult.ValidationErrors)
                    {
                        operationResult.OperationErrors.Add(new ZOperationError("", validationError.ErrorMessage, null, null, new List<string> { validationError.PropertyName }));
                    }
                }
            }
            else
            {
                operationResult.ParseException(exception);
            }
        }
    }
}