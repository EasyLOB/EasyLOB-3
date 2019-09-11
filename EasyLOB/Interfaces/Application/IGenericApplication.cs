using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EasyLOB
{
    public interface IGenericApplication<TEntity> : IDisposable
        where TEntity : class, IZDataBase
    {
        #region Properties

        IGenericRepository<TEntity> Repository { get; }

        IUnitOfWork UnitOfWork { get; }

        IDIManager DIManager { get; }

        IAuthenticationManager AuthenticationManager { get; }

        IAuthorizationManager AuthorizationManager { get; }

        IAuditTrailManager AuditTrailManager { get; }

        ILogManager LogManager { get; }

        ZActivityOperations ActivityOperations { get; }

        #endregion Properties

        #region Methods

        int Count(ZOperationResult operationResult, Expression<Func<TEntity, bool>> where);

        int Count(ZOperationResult operationResult, string where, object[] args = null);

        int CountAll(ZOperationResult operationResult);

        bool Create(ZOperationResult operationResult, TEntity entity, bool beginTransaction = true);

        bool Delete(ZOperationResult operationResult, TEntity entity, bool beginTransaction = true);

        TEntity Get(ZOperationResult operationResult, Expression<Func<TEntity, bool>> where);

        TEntity Get(ZOperationResult operationResult, string where, object[] args = null);

        TEntity GetById(ZOperationResult operationResult, object id);

        TEntity GetById(ZOperationResult operationResult, object[] ids);

        object[] GetIds(TEntity entity);

        IEnumerable<TEntity> Search(ZOperationResult operationResult,
            Expression<Func<TEntity, bool>> where = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null,
            List<Expression<Func<TEntity, object>>> associations = null);

        IEnumerable<TEntity> Search(ZOperationResult operationResult,
            string where = null,
            object[] args = null,
            string orderBy = null,
            int? skip = null,
            int? take = null,
            List<string> associations = null);

        IEnumerable<TEntity> SearchAll(ZOperationResult operationResult);

        bool Update(ZOperationResult operationResult, TEntity entity, bool beginTransaction = true);

        #endregion Methods
    }
}