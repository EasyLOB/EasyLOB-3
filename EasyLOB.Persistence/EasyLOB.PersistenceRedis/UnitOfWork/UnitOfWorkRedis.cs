using EasyLOB.Data;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

// Install-Package ServiceStack.Redis

// localhost
// 127.0.0.1:6379
// redis://localhost:6379
// password @localhost:6379
// clientid: password @localhost:6379
// redis://clientid:password@localhost:6380?ssl=true&db=1

// Redis Transactions works ONLY with Transaction.QueueCommand()

// How to create custom atomic operations in Redis
// https://github.com/ServiceStack/ServiceStack.Redis/wiki/RedisTransactions

// IRedisTransaction
// https://github.com/ServiceStack/ServiceStack.Redis/wiki/IRedisTransaction

//int callbackResult;
//using (var transaction = redis.CreateTransaction())
//{
//  transaction.QueueCommand(r => r.Increment("key"));  
//  transaction.QueueCommand(r => r.Increment("key"), i => callbackResult = i);  
//  transaction.Commit();
//}

namespace EasyLOB.Persistence
{
    public abstract class UnitOfWorkRedis : IUnitOfWork
    {
        #region Properties

        public IAuthenticationManager AuthenticationManager { get; }

        public ZDatabaseLogger DatabaseLogger { get; set; }

        public ZDBMS DBMS
        {
            get { return ZDBMS.Redis; }
        }

        public string Domain { get; protected set; }

        public IDictionary<Type, object> Repositories { get; }

        #endregion Properties

        #region Properties Redis

        public IRedisClient Client { get; protected set; }

        //public IRedisTransaction Transaction { get; }

        #endregion Properties Redis

        #region Methods

        public UnitOfWorkRedis(string host, IAuthenticationManager authenticationManager)
        {
            Client = new RedisClient(host);

            AuthenticationManager = authenticationManager;
            DatabaseLogger = ZDatabaseLogger.None;
            Domain = "";
            Repositories = new Dictionary<Type, object>();
        }

        public virtual void Dispose()
        {
        }

        public virtual bool BeginTransaction(ZOperationResult operationResult, bool isTransaction = true, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            return operationResult.Ok;
        }

        public virtual bool CommitTransaction(ZOperationResult operationResult, bool isTransaction = true)
        {
            return operationResult.Ok;
        }

        public virtual int SQLCommand(string sql)
        {
            throw new NotSupportedException();
        }

        public virtual IEnumerable<T> SQLQuery<T>(string sql)
        {
            throw new NotSupportedException();
        }

        public IZProfile GetProfile<TEntity>()
            where TEntity : class, IZDataBase
        {
            return GetRepository<TEntity>().Profile;
        }

        public virtual IQueryable<TEntity> GetQuery<TEntity>()
            where TEntity : class, IZDataBase
        {
            return GetRepository<TEntity>().Query();
        }

        public virtual IGenericRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class, IZDataBase
        {
            throw new NotImplementedException("abstract class Redis UnitOfWork.GetRepository()");
        }

        public virtual bool RollbackTransaction(ZOperationResult operationResult, bool isTransaction = true)
        {
            return operationResult.Ok;
        }

        public virtual bool Save(ZOperationResult operationResult)
        {
            return operationResult.Ok;
        }

        public void SetIsolationLevel(IsolationLevel isolationLevel)
        {
            //throw new NotImplementedException("abstract class MongoDB UnitOfWork.SetIsolationLevel()");
        }

        #endregion Methods

        #region Triggers
        /*
        public virtual bool BeforeCreate(ZOperationResult operationResult, object entity)
        {
            return operationResult.Ok;
        }

        public virtual bool AfterCreate(ZOperationResult operationResult, object entity)
        {
            return operationResult.Ok;
        }

        public virtual bool BeforeDelete(ZOperationResult operationResult, object entity)
        {
            return operationResult.Ok;
        }

        public virtual bool AfterDelete(ZOperationResult operationResult, object entity)
        {
            return operationResult.Ok;
        }

        public virtual bool BeforeUpdate(ZOperationResult operationResult, object entity)
        {
            return operationResult.Ok;
        }

        public virtual bool AfterUpdate(ZOperationResult operationResult, object entity)
        {
            return operationResult.Ok;
        }
         */
        #endregion Triggers
    }
}