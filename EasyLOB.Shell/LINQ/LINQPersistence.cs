using EasyLOB.AuditTrail;
using EasyLOB.AuditTrail.Data;
using EasyLOB.AuditTrail.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EasyLOB.Shell
{
    partial class Program
    {
        private static void LINQPersistence()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("LINQ Persistence Demo\n");
                Console.WriteLine("<0> RETURN");
                Console.WriteLine("<1> LINQ AuditTrailLog");
                Console.Write("\nChoose an option... ");

                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();

                ZOperationResult operationResult = new ZOperationResult();

                AuditTrailUnitOfWorkEF unitOfWork =
                    (AuditTrailUnitOfWorkEF)ManagerHelper.DIManager.GetService<IAuditTrailUnitOfWork>();
                AuditTrailGenericRepositoryEF<AuditTrailLog> repository =
                    (AuditTrailGenericRepositoryEF<AuditTrailLog>)unitOfWork.GetRepository<AuditTrailLog>();
                IEnumerable<AuditTrailLog> enumerable;
                Expression<Func<AuditTrailLog, bool>> where;
                Func<IQueryable<AuditTrailLog>, IOrderedQueryable<AuditTrailLog>> orderBy;

                switch (key.KeyChar) // <ENTER> = '\r'
                {
                    case ('0'):
                        exit = true;
                        break;

                    case ('1'):
                        int id = 0;

                        Console.WriteLine("\nLINQ");
                        enumerable = repository
                            .Search(x => x.Id > id, o => o.OrderByDescending(x => x.Id));
                        if (operationResult.Ok) 
                        {
                            foreach (AuditTrailLog entity in enumerable)
                            {
                                Console.WriteLine("{0} {1} {2}", entity.Id, entity.LogDate, entity.LogTime);
                            }
                        }

                        Console.WriteLine("\nLINQ with parameters");
                        where = x => x.Id > id;
                        orderBy = o => o.OrderByDescending(x => x.Id);
                        enumerable = repository
                            .Search(where, orderBy);
                        if (operationResult.Ok)
                        {
                            foreach (AuditTrailLog entity in enumerable)
                            {
                                Console.WriteLine("{0} {1} {2}", entity.Id, entity.LogDate, entity.LogTime);
                            }
                        }

                        Console.WriteLine("\nDynamic LINQ");
                        enumerable = repository
                            .Search("Id > @0", new object[] { id }, "Id descending");
                        if (operationResult.Ok)
                        {
                            foreach (AuditTrailLog entity in enumerable)
                            {
                                Console.WriteLine("{0} {1} {2}", entity.Id, entity.LogDate, entity.LogTime);
                            }
                        }

                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("\n{0}\n{1}\n{2}",
                        unitOfWork.GetType().FullName,
                        unitOfWork.DBMS.ToString(),
                        repository.GetType().FullName);

                    if (!operationResult.Ok)
                    {
                        Console.WriteLine(operationResult.Text);
                    }

                    Console.Write("\nPress <KEY> to continue... ");
                    Console.ReadKey();
                }
            }
        }
    }
}