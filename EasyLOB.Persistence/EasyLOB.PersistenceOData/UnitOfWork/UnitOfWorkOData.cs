using EasyLOB.Data;
using Microsoft.OData.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

// Install-Package Microsoft.OData.Client -Version 6.15.0

namespace EasyLOB.Persistence
{
    public abstract class UnitOfWorkOData : IUnitOfWorkDTO
    {
        #region Properties

        public IAuthenticationManager AuthenticationManager { get; }

        public ZDatabaseLogger DatabaseLogger { get; set; }

        public ZDBMS DBMS
        {
            get { return ZDBMS.OData; }
        }

        public string Domain { get; protected set; }

        public IDictionary<Type, object> Repositories { get; }

        #endregion Properties

        #region Properties OData

        public DataServiceContext Container { get; protected set; }

        #endregion Properties OData

        #region Methods

        public UnitOfWorkOData(DataServiceContext container, IAuthenticationManager authenticationManager)
        {
            Container = container;

            AuthenticationManager = authenticationManager;
            DatabaseLogger = ZDatabaseLogger.None;
            Domain = "";
            Repositories = new Dictionary<Type, object>();
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

        public IZProfile GetProfile<TEntityDTO, TEntity>()
            where TEntityDTO : class, IZDTOBase<TEntityDTO, TEntity>
            where TEntity : class, IZDataBase
        {
            return GetRepository<TEntityDTO, TEntity>().Profile;
        }

        public virtual IQueryable<TEntityDTO> GetQuery<TEntityDTO, TEntity>()
            where TEntityDTO : class, IZDTOBase<TEntityDTO, TEntity>
            where TEntity : class, IZDataBase
        {
            return GetRepository<TEntityDTO, TEntity>().Query();
        }

        public virtual IGenericRepositoryDTO<TEntityDTO, TEntity> GetRepository<TEntityDTO, TEntity>()
            where TEntityDTO : class, IZDTOBase<TEntityDTO, TEntity>
            where TEntity : class, IZDataBase
        {
            throw new NotImplementedException("abstract class OData UnitOfWork.GetRepository()");
        }

        public virtual bool RollbackTransaction(ZOperationResult operationResult, bool isTransaction = true)
        {
            return operationResult.Ok;
        }

        public virtual bool Save(ZOperationResult operationResult)
        {
            try
            {
                Container.SaveChanges();
            }
            catch (Exception exception)
            {
                operationResult.ParseExceptionOData(exception);
            }

            return operationResult.Ok;
        }

        public void SetIsolationLevel(IsolationLevel isolationLevel)
        {
            //throw new NotImplementedException("abstract class MongoDB UnitOfWork.SetIsolationLevel()");
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