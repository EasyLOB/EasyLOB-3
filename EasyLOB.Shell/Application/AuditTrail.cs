using EasyLOB.AuditTrail;
using EasyLOB.AuditTrail.Application;
using EasyLOB.AuditTrail.Data;
using EasyLOB.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyLOB.Shell
{
    partial class Program
    {
        private static void ApplicationAuditTrailDemo()
        {
            Console.WriteLine("\nApplication AuditTrail Demo\n");

            ApplicationAuditTrailData<AuditTrailConfiguration>();
            ApplicationAuditTrailDTO<AuditTrailConfigurationDTO, AuditTrailConfiguration>();

            ApplicationAuditTrailData<AuditTrailLog>();
            ApplicationAuditTrailDTO<AuditTrailLogDTO, AuditTrailLog>();
        }

        private static void ApplicationAuditTrailData<TEntity>()
            where TEntity : ZDataBase
        {
            ZOperationResult operationResult = new ZOperationResult();

            IAuditTrailGenericApplication<TEntity> application =
                DIHelper.DIManager.GetService<IAuditTrailGenericApplication<TEntity>>();
            IEnumerable<TEntity> enumerable = application.SearchAll(operationResult);
            if (operationResult.Ok)
            {
                Console.WriteLine(typeof(TEntity).Name + ": {0}", enumerable.Count());
            }
            else
            {
                Console.WriteLine(operationResult.Text);
            }
        }

        private static void ApplicationAuditTrailDTO<TEntityDTO, TEntity>()
            where TEntityDTO : ZDTOBase<TEntityDTO, TEntity>
            where TEntity : ZDataBase
        {
            ZOperationResult operationResult = new ZOperationResult();

            IAuditTrailGenericApplicationDTO<TEntityDTO, TEntity> application =
                DIHelper.DIManager.GetService<IAuditTrailGenericApplicationDTO<TEntityDTO, TEntity>>();
            IEnumerable<TEntityDTO> enumerable = application.SearchAll(operationResult);
            if (operationResult.Ok)
            {
                Console.WriteLine(typeof(TEntity).Name + ": {0}", enumerable.Count());
            }
            else
            {
                Console.WriteLine(operationResult.Text);
            }
        }
    }
}