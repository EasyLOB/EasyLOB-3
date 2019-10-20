using EasyLOB.AuditTrail;
using EasyLOB.AuditTrail.Data;
using EasyLOB.AuditTrail.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
    
namespace EasyLOB.Shell
{
    partial class Program
    {
        private static void LINQEF()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("LINQ Persistence Demo\n");
                Console.WriteLine("<0> RETURN");
                Console.WriteLine("<1> LINQ Entity Framework");
                Console.Write("\nChoose an option... ");

                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();

                ZOperationResult operationResult = new ZOperationResult();

                AuditTrailUnitOfWorkEF unitOfWork =
                    (AuditTrailUnitOfWorkEF)ManagerHelper.DIManager.GetService<IAuditTrailUnitOfWork>();
                IQueryable<AuditTrailLog> query =
                    unitOfWork.GetQuery<AuditTrailLog>();
                IEnumerable<AuditTrailLog> enumerable;
                Expression<Func<AuditTrailLog, bool>> where;
                Expression<Func<AuditTrailLog, int>> orderBy;

                switch (key.KeyChar) // <ENTER> = '\r'
                {
                    case ('0'):
                        exit = true;
                        break;

                    case ('1'):
                        int id = 0;

                        Console.WriteLine("\nLINQ");
                        enumerable = query
                            .Where(x => x.Id > id)
                            .OrderByDescending(o => o.Id)
                            .AsNoTracking() // AppDI*HelperAuditTrail: SingleInstance | AppLifetimeManager
                            .ToList();
                        if (operationResult.Ok) 
                        {
                            foreach (AuditTrailLog entity in enumerable)
                            {
                                Console.WriteLine("{0} {1} {2}", entity.Id, entity.LogDate, entity.LogTime);
                            }
                        }

                        Console.WriteLine("\nLINQ with parameters");
                        where = x => x.Id > id;
                        orderBy = o => o.Id;
                        enumerable = query
                            .Where(where)
                            .OrderByDescending(orderBy)
                            .AsNoTracking() // AppDI*HelperAuditTrail: SingleInstance | AppLifetimeManager
                            .ToList();
                        if (operationResult.Ok)
                        {
                            foreach (AuditTrailLog entity in enumerable)
                            {
                                Console.WriteLine("{0} {1} {2}", entity.Id, entity.LogDate, entity.LogTime);
                            }
                        }

                        Console.WriteLine("\nDynamic LINQ");
                        enumerable = query
                            .Where("Id > @0", new object[] { id })
                            .OrderBy("Id descending")
                            .AsNoTracking() // AppDI*HelperAuditTrail: SingleInstance | AppLifetimeManager
                            .ToList();
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
                        query.GetType().FullName);

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