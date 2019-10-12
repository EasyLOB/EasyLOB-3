using EasyLOB.Data;
using LinqToDB.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

// Install-Package linq2db

namespace EasyLOB.Persistence
{
    public abstract class UnitOfWorkLINQ2DB : IUnitOfWork
    {
        #region Properties

        public IAuthenticationManager AuthenticationManager { get; }

        public ZDatabaseLogger DatabaseLogger { get; set; }

        public ZDBMS DBMS
        {
            get { return AdoNetHelper.GetDBMS(Connection.DataProvider.ConnectionNamespace); }
        }

        public string Domain { get; protected set; }

        public IDictionary<Type, object> Repositories { get; }

        #endregion Properties

        #region Properties LINQ to DB

        public DataConnection Connection { get; protected set; }

        public DataConnectionTransaction Transaction { get; protected set; }

        #endregion Properties LINQ to DB

        #region Methods

        public UnitOfWorkLINQ2DB(DataConnection connection, IAuthenticationManager authenticationManager)
        {
            Connection = connection;

            AuthenticationManager = authenticationManager;
            DatabaseLogger = ZDatabaseLogger.None;
            Domain = "";
            Repositories = new Dictionary<Type, object>();
        }

        public virtual bool BeginTransaction(ZOperationResult operationResult, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            try
            {
                if (PersistenceHelper.IsTransaction)
                {
                    if (Transaction == null || Transaction.DataConnection == null)
                    {
                        Transaction = Connection.BeginTransaction(isolationLevel);
                    }
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseExceptionLINQ2DB(exception);
            }

            return operationResult.Ok;
        }

        public virtual bool CommitTransaction(ZOperationResult operationResult)
        {
            try
            {
                if (PersistenceHelper.IsTransaction)
                {
                    if (Transaction != null)
                    {
                        if (Transaction.DataConnection != null
                            && Transaction.DataConnection.Connection != null
                            && Transaction.DataConnection.Connection.State == ConnectionState.Open)
                        {
                            Transaction.Commit();
                        }

                        Transaction.Dispose();
                        Transaction = null;
                    }
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseExceptionLINQ2DB(exception);
            }

            return operationResult.Ok;
        }

        public virtual int SQLCommand(string sql)
        {
            return Connection.Execute(sql);
        }

        public virtual IEnumerable<T> SQLQuery<T>(string sql)
        {
            return Connection.ExecuteReader(sql).Query<T>();
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
            throw new NotImplementedException("abstract class LINQ to DB UnitOfWork.GetRepository()");

            //if (!Repositories.Keys.Contains(typeof(TEntity)))
            //{
            //    var repository = new GenericRepository<TEntity>(Context);
            //    Repositories.Add(typeof(TEntity), repository);
            //}

            //return Repositories[typeof(TEntity)] as IGenericRepository<TEntity>;
        }

        public virtual bool RollbackTransaction(ZOperationResult operationResult)
        {
            try
            {
                if (PersistenceHelper.IsTransaction)
                {
                    if (Transaction != null)
                    {
                        if (Transaction.DataConnection != null
                            && Transaction.DataConnection.Connection != null
                            && Transaction.DataConnection.Connection.State == ConnectionState.Open)
                        {
                            Transaction.Commit();
                        }

                        Transaction.Dispose();
                        Transaction = null;
                    }
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseExceptionLINQ2DB(exception);
            }

            return operationResult.Ok;
        }

        public virtual bool Save(ZOperationResult operationResult)
        {
            return operationResult.Ok;
        }

        public void SetIsolationLevel(IsolationLevel isolationLevel)
        {
            ZDBMS dbms = AdoNetHelper.GetDBMS(Connection.ConnectionString);
            string sql = AdoNetHelper.SqlIsolationLevel(dbms, isolationLevel);
            if (!String.IsNullOrEmpty(sql))
            {
                SQLCommand(sql);
            }
        }

        #endregion Methods

        #region Methods IDispose

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (Transaction != null)
                    {
                        Transaction.Dispose();
                        Transaction = null;
                    }
                }

                disposed = true;
            }
        }

        #endregion Methods IDispose

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