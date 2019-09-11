using EasyLOB.AuditTrail.Data;
using EasyLOB.Data;
using EasyLOB.Environment;
using EasyLOB.Persistence;
using Newtonsoft.Json;
using System;

namespace EasyLOB.AuditTrail
{
    public class AuditTrailManager : IAuditTrailManager
    {
        #region Properties

        public IAuditTrailUnitOfWork UnitOfWork { get; }

        #endregion Properties

        #region Methods

        public AuditTrailManager(IAuditTrailUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public virtual void Dispose()
        {
        }

        public bool AuditTrail(ZOperationResult operationResult, string logUserName, string logDomain, string logEntity, string logOperation, IZDataBase entityBefore, IZDataBase entityAfter)
        {
            string logMode;

            if (IsAuditTrail(logDomain, logEntity, logOperation, out logMode))
            {
                // (N) None
                // (K) Entity Key
                // (E) Full Entity
                if (!(String.IsNullOrEmpty(logMode) || logMode == "N"))
                {
                    JsonSerializerSettings jsonSettings = new JsonSerializerSettings
                    {
                        //Formatting = Formatting.Indented
                        Formatting = Formatting.None,
                        MaxDepth = 1
                    };

                    object[] ids;
                    IZProfile profile;
                    if (entityAfter != null)
                    {
                        ids = entityAfter.GetId();
                        profile = DataHelper.GetProfile(entityAfter.GetType());
                    }
                    else // entityBefore != null
                    {
                        ids = entityBefore.GetId();
                        profile = DataHelper.GetProfile(entityBefore.GetType());
                    }

                    // 1|2
                    string logId = "";
                    int idIndex = 0;
                    foreach (string idProperty in profile.Keys)
                    {
                        logId += (String.IsNullOrEmpty(logId) ? "" : "|") + JsonConvert.SerializeObject(ids[idIndex++], jsonSettings);
                    }

                    // {"Id1":1,"Id2":2}
                    //string logId = "";
                    //int idIndex = 0;
                    //foreach (string idProperty in profile.Keys)
                    //{
                    //    logId += (String.IsNullOrEmpty(logId) ? "" : ",") + "\"" + idProperty + "\":" + JsonConvert.SerializeObject(ids[idIndex++], settings);
                    //}
                    //logId = "{" + logId + "}";

                    AuditTrailLog auditTrailLog = new AuditTrailLog();
                    auditTrailLog.LogDate = DateTime.Today;
                    auditTrailLog.LogTime = DateTime.Now;
                    auditTrailLog.LogUserName = logUserName;
                    auditTrailLog.LogDomain = logDomain;
                    auditTrailLog.LogEntity = logEntity;
                    auditTrailLog.LogOperation = logOperation;
                    // K
                    auditTrailLog.LogId = logId;
                    // E
                    if (logMode == "E")
                    {
                        auditTrailLog.LogEntityBefore = entityBefore == null ? "" : JsonConvert.SerializeObject(entityBefore, jsonSettings);
                        auditTrailLog.LogEntityAfter = entityAfter == null ? "" : JsonConvert.SerializeObject(entityAfter, jsonSettings);
                    }

                    IGenericRepository<AuditTrailLog> repository = UnitOfWork.GetRepository<AuditTrailLog>();
                    if (repository.Create(operationResult, auditTrailLog))
                    {
                        UnitOfWork.Save(operationResult);
                    }
                }
            }

            return operationResult.Ok;
        }

        public bool IsAuditTrail(string logDomain, string logEntity, string logOperation, out string logMode)
        {
            bool result = false;
            logMode = "N";

            if (AuditTrailHelper.IsAuditTrail)
            {
                foreach (AppProfileAuditTrail auditTrail in ProfileHelper.Profile.AuditTrail)
                {
                    if (auditTrail.Domain == logDomain && auditTrail.Entity == logEntity)
                    {
                        if (auditTrail.LogOperations.Contains(logOperation))
                        {
                            result = true;
                            logMode = auditTrail.LogMode;
                        }

                        break;
                    }
                }

                //AuditTrailConfiguration auditTrailConfiguration = UnitOfWork
                //    .GetRepository<AuditTrailConfiguration>()
                //    .Get(x => x.Domain == logDomain && x.Entity == logEntity && x.LogOperations.Contains(logOperation));
                //if (auditTrailConfiguration != null)
                //{
                //    result = true;
                //    logMode = auditTrailConfiguration.LogMode;
                //}
            }

            return result;
        }

        #endregion Methods
    }
}