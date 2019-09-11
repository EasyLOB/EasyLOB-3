using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace EasyLOB
{
    /// <summary>
    /// IUnitOfWorkDTO.
    /// </summary>
    public interface IUnitOfWorkDTO : IDisposable
    {
        #region Properties

        /// <summary>
        /// Authentication Manager.
        /// </summary>
        IAuthenticationManager AuthenticationManager { get; }

        /// <summary>
        /// Logger.
        /// </summary>
        ZDatabaseLogger DatabaseLogger { get; set; }

        /// <summary>
        /// DBMS.
        /// </summary>
        ZDBMS DBMS { get; }

        /// <summary>
        /// Domain.
        /// </summary>
        string Domain { get; }

        /// <summary>
        /// Repositories.
        /// </summary>
        IDictionary<Type, object> Repositories { get; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Begin Transaction.
        /// </summary>
        /// <param name="operationResult">Operation Result</param>
        /// <param name="beginTransaction">Begin Transaction ?</param>
        /// <param name="isolationLevel">Isolation Level</param>
        /// <returns>Ok ?</returns>
        bool BeginTransaction(ZOperationResult operationResult, bool beginTransaction = true, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);

        /// <summary>
        /// Commit Transaction.
        /// </summary>
        /// <param name="operationResult">Operation Result</param>
        /// <param name="beginTransaction">Begin Transaction ?</param>
        /// <returns>Ok ?</returns>
        bool CommitTransaction(ZOperationResult operationResult, bool beginTransaction = true);

        /// <summary>
        /// Execute SQL Command.
        /// </summary>
        /// <param name="sql">SQL</param>
        /// <returns>Scalar</returns>
        int SQLCommand(string sql);

        /// <summary>
        /// Execute SQL Query.
        /// </summary>
        /// <param name="sql">SQL</param>
        /// <returns>IEnumerable[T]></returns>
        IEnumerable<T> SQLQuery<T>(string sql);

        /// <summary>
        /// Get Profile.
        /// </summary>
        /// <typeparam name="TEntityDTO">DTO</typeparam>
        /// <typeparam name="TEntity">Entity</typeparam>
        /// <returns>Data Profile</returns>
        IZProfile GetProfile<TEntityDTO, TEntity>()
            where TEntityDTO : class, IZDTOBase<TEntityDTO, TEntity>
            where TEntity : class, IZDataBase;

        /// <summary>
        /// Get IQueryable.
        /// </summary>
        /// <typeparam name="TEntityDTO">DTO</typeparam>
        /// <typeparam name="TEntity">Entity</typeparam>
        /// <returns>Ok ?</returns>
        IQueryable<TEntityDTO> GetQuery<TEntityDTO, TEntity>()
            where TEntityDTO : class, IZDTOBase<TEntityDTO, TEntity>
            where TEntity : class, IZDataBase;

        /// <summary>
        /// Get Repository.
        /// </summary>
        /// <typeparam name="TEntityDTO">DTO</typeparam>
        /// <typeparam name="TEntity">Entity</typeparam>
        /// <returns>Ok ?</returns>
        IGenericRepositoryDTO<TEntityDTO, TEntity> GetRepository<TEntityDTO, TEntity>()
            where TEntityDTO : class, IZDTOBase<TEntityDTO, TEntity>
            where TEntity : class, IZDataBase;

        /// <summary>
        /// Rollback Transaction.
        /// </summary>
        /// <param name="operationResult">Operation Result</param>
        /// <param name="beginTransaction">Begin Transaction ?</param>
        /// <returns>Ok ?</returns>
        bool RollbackTransaction(ZOperationResult operationResult, bool beginTransaction = true);

        bool Save(ZOperationResult operationResult);

        #endregion Methods

        #region Triggers
        /*
        /// <summary>
        /// Before create Trigger.
        /// </summary>
        /// <param name="operationResult">Operation Result</param>
        /// <param name="entity">Entity</param>
        /// <returns>Ok ?</returns>
        bool BeforeCreate(ZOperationResult operationResult, object entity);

        /// <summary>
        /// After create Trigger.
        /// </summary>
        /// <param name="operationResult">Operation Result</param>
        /// <param name="entity">Entity</param>
        /// <returns>Ok ?</returns>
        bool AfterCreate(ZOperationResult operationResult, object entity);

        /// <summary>
        /// Before delete Trigger.
        /// </summary>
        /// <param name="operationResult">Operation Result</param>
        /// <param name="entity">Entity</param>
        /// <returns>Ok ?</returns>
        bool BeforeDelete(ZOperationResult operationResult, object entity);

        /// <summary>
        /// After delete Trigger.
        /// </summary>
        /// <param name="operationResult">Operation Result</param>
        /// <param name="entity">Entity</param>
        /// <returns>Ok ?</returns>
        bool AfterDelete(ZOperationResult operationResult, object entity);

        /// <summary>
        /// Before udpate Trigger.
        /// </summary>
        /// <param name="operationResult">Operation Result</param>
        /// <param name="entity">Entity</param>
        /// <returns>Ok ?</returns>
        bool BeforeUpdate(ZOperationResult operationResult, object entity);

        /// <summary>
        /// After update Trigger.
        /// </summary>
        /// <param name="operationResult">Operation Result</param>
        /// <param name="entity">Entity</param>
        /// <returns>Ok ?</returns>
        bool AfterUpdate(ZOperationResult operationResult, object entity);
         */
        #endregion Triggers
    }
}