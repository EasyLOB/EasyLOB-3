using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EasyLOB
{
    /// <summary>
    /// IGenericRepository.
    /// </summary>
    /// <typeparam name="TEntity">Data entity</typeparam>
    public interface IGenericRepository<TEntity> : IDisposable
        where TEntity : class, IZDataBase
    {
        #region Properties

        /// <summary>
        /// Z Profile.
        /// </summary>
        IZProfile Profile { get; }

        /// <summary>
        /// Entity.
        /// </summary>
        string Entity { get; }

        /// <summary>
        /// Joins.
        /// </summary>
        int Joins { get; }

        /// <summary>
        /// Unit of Work.
        /// </summary>
        IUnitOfWork UnitOfWork { get; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Count.
        /// </summary>
        /// <param name="where">Where LINQ expression</param>
        /// <returns>Count</returns>
        int Count(Expression<Func<TEntity, bool>> where);

        /// <summary>
        /// Count
        /// </summary>
        /// <param name="where">Where LINQ expression</param>
        /// <param name="args">Arguments</param>
        /// <returns>Count</returns>
        int Count(string where, object[] args = null);

        /// <summary>
        /// Count ALL.
        /// </summary>
        /// <returns>Count</returns>
        int CountAll();

        /// <summary>
        /// Create.
        /// </summary>
        /// <param name="operationResult">Operation Result</param>
        /// <param name="entity">Entity</param>
        /// <returns>Ok ?</returns>
        bool Create(ZOperationResult operationResult, TEntity entity);

        /// <summary>
        /// Delete.
        /// </summary>
        /// <param name="operationResult">Operation Result</param>
        /// <param name="entity">Entity</param>
        /// <returns>Ok ?</returns>
        bool Delete(ZOperationResult operationResult, TEntity entity);

        /// <summary>
        /// Filter Where LINQ expression.
        /// </summary>
        /// <param name="where">Where LINQ expression</param>
        void Filter(Expression<Func<TEntity, bool>> where);

        /// <summary>
        /// Filter Where Dynamic LINQ expression.
        /// </summary>
        /// <param name="where">Where DynamicLINQ expression</param>
        /// <param name="args">Arguments</param>
        void Filter(ref string where, ref object[] args);

        /// <summary>
        /// Get.
        /// </summary>
        /// <param name="where">Where LINQ expression</param>
        /// <returns>Entity</returns>
        TEntity Get(Expression<Func<TEntity, bool>> where);

        /// <summary>
        /// Get.
        /// </summary>
        /// <param name="where">Where Dynamic LINQ expression</param>
        /// <param name="args">Arguments</param>
        /// <returns>Entity</returns>
        TEntity Get(string where, object[] args = null);

        /// <summary>
        /// Get by Id.
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Entity</returns>
        TEntity GetById(object id);

        /// <summary>
        /// Get by Id.
        /// </summary>
        /// <param name="ids">Ids</param>
        /// <returns>Entity</returns>
        TEntity GetById(object[] ids);

        /// <summary>
        /// Get Ids.
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Ids</returns>
        object[] GetIds(TEntity entity);

        /// <summary>
        /// Get Next DBMS Sequence.
        /// </summary>
        /// <returns>DBMS Sequence</returns>
        object GetNextSequence();

        /// <summary>
        /// Join.
        /// </summary>
        /// <param name="entity">Entity</param>
        void Join(TEntity entity);

        /// <summary>
        /// Join.
        /// </summary>
        /// <param name="enumerable">Entities</param>
        void Join(IEnumerable<TEntity> enumerable);

        /// <summary>
        /// Join.
        /// </summary>
        /// <param name="query">IQueryable</param>
        /// <returns>IQueryable</returns>
        IQueryable<TEntity> Join(IQueryable<TEntity> query);

        /// <summary>
        /// Join.
        /// </summary>
        /// <param name="query">IQueryable</param>
        /// <param name="associations">Associations LINQ expression</param>
        /// <returns>IQueryable</returns>
        IQueryable<TEntity> Join(IQueryable<TEntity> query, List<Expression<Func<TEntity, object>>> associations = null);

        /// <summary>
        /// Join.
        /// </summary>
        /// <param name="query">IQueryable</param>
        /// <param name="associations">Associations</param>
        /// <returns></returns>
        IQueryable<TEntity> Join(IQueryable<TEntity> query, List<string> associations = null);

        /// <summary>
        /// IQueryable.
        /// </summary>
        /// <returns>IQueryable</returns>
        IQueryable<TEntity> Query();

        /// <summary>
        /// IQueryable.
        /// </summary>
        /// <param name="where">Where LINQ expression</param>
        /// <param name="orderBy">Order By LINQ expression</param>
        /// <param name="skip">Records to skip</param>
        /// <param name="take">Records to take</param>
        /// <param name="associations">Associations LINQ expression</param>
        /// <returns>IQueryable</returns>
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> where = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null,
            //List<string> associations = null);
            List<Expression<Func<TEntity, object>>> associations = null);

        /// <summary>
        /// IQueryable.
        /// </summary>
        /// <param name="where">Where Dynamic LINQ expression</param>
        /// <param name="args">Arguments</param>
        /// <param name="orderBy">Order By Dynamic LINQ expression</param>
        /// <param name="skip">Records to skip</param>
        /// <param name="take">Records to take</param>
        /// <param name="associations">Associations</param>
        /// <returns>IQueryable</returns>
        IQueryable<TEntity> Query(string where = null,
            object[] args = null,
            string orderBy = null,
            int? skip = null,
            int? take = null,
            List<string> associations = null);

        /// <summary>
        /// Search.
        /// </summary>
        /// <param name="where">Where LINQ expression</param>
        /// <param name="orderBy">Order By LINQ expression</param>
        /// <param name="skip">Records to skip</param>
        /// <param name="take">Records to take</param>
        /// <param name="associations">Associations LINQ expression</param>
        /// <returns>IEnumerable</returns>
        IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> where = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null,
            //List<string> associations = null);
            List<Expression<Func<TEntity, object>>> associations = null);

        /// <summary>
        /// Search.
        /// </summary>
        /// <param name="where">Where Dynamic LINQ expression</param>
        /// <param name="args">Arguments</param>
        /// <param name="orderBy">Order By Dynamic LINQ expression</param>
        /// <param name="skip">Records to skip</param>
        /// <param name="take">Records to take</param>
        /// <param name="associations">Associations</param>
        /// <returns>IEnumerable</returns>
        IEnumerable<TEntity> Search(string where = null,
            object[] args = null,
            string orderBy = null,
            int? skip = null,
            int? take = null,
            List<string> associations = null);

        /// <summary>
        /// Search ALL.
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> SearchAll();

        /// <summary>
        /// Set DBMS Sequence.
        /// </summary>
        /// <param name="value">Sequence = Id + 1</param>
        /// <returns></returns>
        void SetSequence(int value);

        /// <summary>
        /// Update.
        /// </summary>
        /// <param name="operationResult">Operation Result</param>
        /// <param name="entity">Entity</param>
        /// <returns>Ok ?</returns>
        bool Update(ZOperationResult operationResult, TEntity entity);

        #endregion Methods

        #region Methods *AndSave

        bool CreateAndSave(ZOperationResult operationResult, TEntity entity);

        bool DeleteAndSave(ZOperationResult operationResult, TEntity entity);

        bool UpdateAndSave(ZOperationResult operationResult, TEntity entity);

        #endregion Methods *AndSave

        #region Triggers

        /// <summary>
        /// Before create Trigger.
        /// </summary>
        /// <param name="operationResult">Operation Result</param>
        /// <param name="entity">Entity</param>
        /// <returns>Ok ?</returns>
        bool BeforeCreate(ZOperationResult operationResult, TEntity entity);

        /// <summary>
        /// After create Trigger.
        /// </summary>
        /// <param name="operationResult">Operation Result</param>
        /// <param name="entity">Entity</param>
        /// <returns>Ok ?</returns>
        bool AfterCreate(ZOperationResult operationResult, TEntity entity);

        /// <summary>
        /// Before delete Trigger.
        /// </summary>
        /// <param name="operationResult">Operation Result</param>
        /// <param name="entity">Entity</param>
        /// <returns>Ok ?</returns>
        bool BeforeDelete(ZOperationResult operationResult, TEntity entity);

        /// <summary>
        /// After delete Trigger.
        /// </summary>
        /// <param name="operationResult">Operation Result</param>
        /// <param name="entity">Entity</param>
        /// <returns>Ok ?</returns>
        bool AfterDelete(ZOperationResult operationResult, TEntity entity);

        /// <summary>
        /// Before update Trigger.
        /// </summary>
        /// <param name="operationResult">Operation Result</param>
        /// <param name="entity">Entity</param>
        /// <returns>Ok ?</returns>
        bool BeforeUpdate(ZOperationResult operationResult, TEntity entity);

        /// <summary>
        /// After update Trigger.
        /// </summary>
        /// <param name="operationResult">Operation Result</param>
        /// <param name="entity">Entity</param>
        /// <returns>Ok ?</returns>
        bool AfterUpdate(ZOperationResult operationResult, TEntity entity);

        #endregion Triggers
    }
}