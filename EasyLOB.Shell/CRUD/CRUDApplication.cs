using EasyLOB.AuditTrail;
using EasyLOB.AuditTrail.Data;
using System;
using System.Collections.Generic;

namespace EasyLOB.Shell
{
    partial class Program
    {
        private static void CRUDApplication()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("CRUD Application Demo\n");
                Console.WriteLine("<0> RETURN");
                Console.WriteLine("<1> CREATE AuditTrailLog");
                Console.WriteLine("<2> UPDATE AuditTrailLog");
                Console.WriteLine("<3> DELETE AuditTrailLog");
                Console.WriteLine("<4> TRANSACTION COMMIT AuditTrailLog");
                Console.WriteLine("<5> TRANSACTION ROLLBAK AuditTrailLog");
                Console.WriteLine("<T> TRUNCATE TABLE AuditTrailLog");
                Console.Write("\nChoose an option... ");

                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();

                ZOperationResult operationResult = new ZOperationResult();

                IAuditTrailGenericApplication<AuditTrailLog> application = 
                    ManagerHelper.DIManager.GetService<IAuditTrailGenericApplication<AuditTrailLog>>();
                AuditTrailLog auditTrailLog;

                switch (key.KeyChar) // <ENTER> = '\r'
                {
                    case ('0'):
                        exit = true;
                        break;

                    case ('1'):
                        auditTrailLog = new AuditTrailLog();
                        auditTrailLog.LogDate = DateTime.Today;
                        auditTrailLog.LogTime = DateTime.Now;
                        application.Create(operationResult, auditTrailLog);

                        break;

                    case ('2'):
                        auditTrailLog = new AuditTrailLog();
                        auditTrailLog.LogDate = DateTime.Today;
                        auditTrailLog.LogTime = DateTime.Now;
                        if (application.Create(operationResult, auditTrailLog))
                        {
                            auditTrailLog.LogDate = DateTime.Today.AddMonths(1);
                            auditTrailLog.LogTime = DateTime.Now.AddMonths(1);
                            application.Update(operationResult, auditTrailLog);
                        }

                        break;

                    case ('3'):
                        auditTrailLog = new AuditTrailLog();
                        auditTrailLog.LogDate = DateTime.Today;
                        auditTrailLog.LogTime = DateTime.Now;
                        if (application.Create(operationResult, auditTrailLog))
                        {
                            application.Delete(operationResult, auditTrailLog);
                        }

                        break;

                    case ('4'):
                        try
                        {
                            if (application.UnitOfWork.BeginTransaction(operationResult))
                            {
                                auditTrailLog = new AuditTrailLog();
                                auditTrailLog.LogDate = DateTime.Today;
                                auditTrailLog.LogTime = DateTime.Now;
                                if (application.Create(operationResult, auditTrailLog))
                                {
                                    auditTrailLog.LogDate = DateTime.Today.AddMonths(1);
                                    auditTrailLog.LogTime = DateTime.Now.AddMonths(1);
                                    if (application.Update(operationResult, auditTrailLog))
                                    {
                                        application.UnitOfWork.CommitTransaction(operationResult);
                                    }
                                }
                            }
                        }
                        catch (Exception exception)
                        {
                            operationResult.ParseException(exception);
                        }

                        if (!operationResult.Ok)
                        {
                            application.UnitOfWork.RollbackTransaction(operationResult);
                        }

                        break;

                    case ('5'):
                        try
                        {
                            if (application.UnitOfWork.BeginTransaction(operationResult))
                            {
                                auditTrailLog = new AuditTrailLog();
                                auditTrailLog.LogDate = DateTime.Today;
                                auditTrailLog.LogTime = DateTime.Now;
                                if (application.Create(operationResult, auditTrailLog))
                                {
                                    auditTrailLog.LogDate = DateTime.Today.AddMonths(1);
                                    auditTrailLog.LogTime = DateTime.Now.AddMonths(1);
                                    if (application.Update(operationResult, auditTrailLog))
                                    {
                                        application.UnitOfWork.RollbackTransaction(operationResult);
                                    }
                                }
                            }
                        }
                        catch (Exception exception)
                        {
                            operationResult.ParseException(exception);
                        }

                        if (!operationResult.Ok)
                        {
                            application.UnitOfWork.RollbackTransaction(operationResult);
                        }

                        break;

                    case ('t'):
                    case ('T'):
                        application.UnitOfWork.SQLCommand("TRUNCATE TABLE EasyLOBAuditTrailLog");
                        break;
                }

                if (!exit)
                {
                    if (operationResult.Ok)
                    {
                        List<AuditTrailLog> list = (List<AuditTrailLog>)application.SearchAll(operationResult);
                        if (operationResult.Ok)
                        {
                            foreach (AuditTrailLog entity in list)
                            {
                                Console.WriteLine("{0} {1} {2}", entity.Id, entity.LogDate, entity.LogTime);
                            }
                        }
                    }

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