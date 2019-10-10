using EasyLOB.AuditTrail;
using EasyLOB.AuditTrail.Data;
using EasyLOB.AuditTrail.Persistence;
using System;
using System.Collections.Generic;

namespace EasyLOB.Shell
{
    partial class Program
    {
        private static void CRUDPersistence()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("CRUD Persistence Demo\n");
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

                AuditTrailUnitOfWorkEF unitOfWork =
                    (AuditTrailUnitOfWorkEF)ManagerHelper.DIManager.GetService<IAuditTrailUnitOfWork>();
                AuditTrailGenericRepositoryEF<AuditTrailLog> repository =
                    (AuditTrailGenericRepositoryEF<AuditTrailLog>)unitOfWork.GetRepository<AuditTrailLog>();
                AuditTrailLog auditTrailLog;
                ZOperationResult operationResult = new ZOperationResult();

                switch (key.KeyChar) // <ENTER> = '\r'
                {
                    case ('0'):
                        exit = true;
                        break;

                    case ('1'):
                        auditTrailLog = new AuditTrailLog();
                        auditTrailLog.LogDate = DateTime.Today;
                        auditTrailLog.LogTime = DateTime.Now;
                        if (repository.Create(operationResult, auditTrailLog))
                        {
                            unitOfWork.Save(operationResult);
                        }

                        break;

                    case ('2'):
                        auditTrailLog = new AuditTrailLog();
                        auditTrailLog.LogDate = DateTime.Today;
                        auditTrailLog.LogTime = DateTime.Now;
                        if (repository.Create(operationResult, auditTrailLog))
                        {
                            auditTrailLog.LogDate = DateTime.Today;
                            auditTrailLog.LogTime = DateTime.Now;
                            if (unitOfWork.Save(operationResult))
                            {
                                auditTrailLog.LogDate = DateTime.Today.AddMonths(1);
                                auditTrailLog.LogTime = DateTime.Now.AddMonths(1);
                                if (repository.Update(operationResult, auditTrailLog))
                                {
                                    unitOfWork.Save(operationResult);
                                }
                            }
                        }

                        break;

                    case ('3'):
                        auditTrailLog = new AuditTrailLog();
                        auditTrailLog.LogDate = DateTime.Today;
                        auditTrailLog.LogTime = DateTime.Now;
                        if (repository.Create(operationResult, auditTrailLog))
                        {
                            if (unitOfWork.Save(operationResult))
                            {
                                if (repository.Delete(operationResult, auditTrailLog))
                                {
                                    unitOfWork.Save(operationResult);
                                }
                            }
                        }

                        break;

                    case ('4'):
                        try
                        {
                            if (unitOfWork.BeginTransaction(operationResult))
                            {
                                auditTrailLog = new AuditTrailLog();
                                auditTrailLog.LogDate = DateTime.Today;
                                auditTrailLog.LogTime = DateTime.Now;
                                if (repository.Create(operationResult, auditTrailLog))
                                {
                                    if (unitOfWork.Save(operationResult))
                                    {
                                        auditTrailLog.LogDate = DateTime.Today.AddMonths(1);
                                        auditTrailLog.LogTime = DateTime.Now.AddMonths(1);
                                        if (repository.Update(operationResult, auditTrailLog))
                                        {
                                            if (unitOfWork.Save(operationResult))
                                            {
                                                unitOfWork.CommitTransaction(operationResult);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception exception)
                        {
                            WriteException(exception);
                        }

                        break;

                    case ('5'):
                        try
                        {
                            if (unitOfWork.BeginTransaction(operationResult))
                            {
                                auditTrailLog = new AuditTrailLog();
                                auditTrailLog.LogDate = DateTime.Today;
                                auditTrailLog.LogTime = DateTime.Now;
                                if (repository.Create(operationResult, auditTrailLog))
                                {
                                    if (unitOfWork.Save(operationResult))
                                    {
                                        auditTrailLog.LogDate = DateTime.Today.AddMonths(1);
                                        auditTrailLog.LogTime = DateTime.Now.AddMonths(1);
                                        if (repository.Update(operationResult, auditTrailLog))
                                        {
                                            if (unitOfWork.Save(operationResult))
                                            {
                                                unitOfWork.RollbackTransaction(operationResult);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception exception)
                        {
                            WriteException(exception);
                        }

                        break;

                    case ('t'):
                    case ('T'):
                        unitOfWork.SQLCommand("TRUNCATE TABLE EasyLOBAuditTrailLog");
                        break;
                }

                if (operationResult.Ok)
                {
                    List<AuditTrailLog> list = (List<AuditTrailLog>)repository.SearchAll();
                    foreach (AuditTrailLog entity in list)
                    {
                        Console.WriteLine("{0} {1} {2}", entity.Id, entity.LogDate, entity.LogTime);
                    }
                }
                else
                {
                    Console.WriteLine(operationResult.Text);
                }

                if (!exit)
                {
                    Console.Write("\nPress <KEY> to continue... ");
                    Console.ReadKey();
                }
            }
        }
    }
}