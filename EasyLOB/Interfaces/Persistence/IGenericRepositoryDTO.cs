using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EasyLOB
{
    /// <summary>
    /// IGenericRepositoryDTO.
    /// </summary>
    /// <typeparam name="TEntityDTO">DTO entity</typeparam>
    /// <typeparam name="TEntity">Data entity</typeparam>
    public interface IGenericRepositoryDTO<TEntityDTO, TEntity> : IDisposable
        where TEntityDTO : class, IZDTOBase<TEntityDTO, TEntity>
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
        IUnitOfWorkDTO UnitOfWork { get; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Count.
        /// </summary>
        /// <param name="where">Where LINQ expression</param>
        /// <returns>Count</returns>
        int Count(Expression<Func<TEntityDTO, bool>> where);

        /// <summary>
        /// Count.
        /// </summary>
        /// <param name="where">Where Dynamic LINQ expression</param>
        /// <param name="args">Arguments</param>
        /// <returns>Count</returns>
        int Count(string where, object[] args = null);

        /// <summary>
        /// Count ALL.
        /// </summary>
        /// <returns></returns>
        int CountAll();

        /// <summary>
        /// Create.
        /// </summary>
        /// <param name="operationResult">Operation Result</param>
        /// <param name="entity">Entity DTO</param>
        /// <returns>Ok ?</returns>
        bool Create(ZOperationResult operationResult, TEntityDTO entity);

        /// <summary>
        /// Delete.
        /// </summary>
        /// <param name="operationResult">Operation Result</param>
        /// <param name="entity">Entity DTO</param>
        /// <returns>Ok ?</returns>
        bool Delete(ZOperationResult operationResult, TEntityDTO entity);

        /// <summary>
        /// Filter Where LINQ expression.
        /// </summary>
        /// <param name="where">Where LINQ expression</param>
        void Filter(Expression<Func<TEntityDTO, bool>> where);

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
        /// <returns>Entity DTO</returns>
        TEntityDTO Get(Expression<Func<TEntityDTO, bool>> where);

        /// <summary>
        /// Get.
        /// </summary>
        /// <param name="where">Where Dynamic LINQ expression</param>
        /// <param name="args">Arguments</param>
        /// <returns>Entity DTO</returns>
        TEntityDTO Get(string where, object[] args = null);

        /// <summary>
        /// Get by Id.
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Entity DTO</returns>
        TEntityDTO GetById(object id);

        /// <summary>
        /// Get by Id.
        /// </summary>
        /// <param name="ids">Ids</param>
        /// <returns>Entity DTO</returns>
        TEntityDTO GetById(object[] ids);

        /// <summary>
        /// Get Ids.
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Ids</returns>
        object[] GetIds(TEntityDTO entity);

        /// <summary>
        /// Get Next DBMS Sequence.
        /// </summary>
        /// <returns>DBMS Sequence</returns>
        object GetNextSequence();

        /// <summary>
        /// Join.
        /// </summary>
        /// <param name="entity">Entity DTO</param>
        void Join(TEntityDTO entity);

        /// <summary>
        /// Join.
        /// </summary>
        /// <param name="enumerable">IEnumerable</param>
        void Join(IEnumerable<TEntityDTO> enumerable);

        /// <summary>
        /// Join.
        /// </summary>
        /// <param name="query">IQueryable</param>
        /// <returns>IQueryable</returns>
        IQueryable<TEntityDTO> Join(IQueryable<TEntityDTO> query);

        /// <summary>
        /// Join.
        /// </summary>
        /// <param name="query">IQueryable</param>
        /// <param name="associations">Associations LINQ expression</param>
        /// <returns></returns>
        IQueryable<TEntityDTO> Join(IQueryable<TEntityDTO> query, List<Expression<Func<TEntityDTO, object>>> associations = null);

        /// <summary>
        /// Join.
        /// </summary>
        /// <param name="query">IQueryable</param>
        /// <param name="associations">Associations</param>
        /// <returns>IQueryable</returns>
        IQueryable<TEntityDTO> Join(IQueryable<TEntityDTO> query, string[] associations = null);

        /// <summary>
        /// IQueryable.
        /// </summary>
        /// <returns>IQueryable</returns>
        IQueryable<TEntityDTO> Query();

        /// <summary>
        /// IQueryable.
        /// </summary>
        /// <param name="where">Where LINQ expression</param>
        /// <param name="orderBy">Order By LINQ expression</param>
        /// <param name="skip">Records to skip</param>
        /// <param name="take">Records to take</param>
        /// <param name="associations">Associations LINQ expression</param>
        /// <returns>IQueryable</returns>
        IQueryable<TEntityDTO> Query(Expression<Func<TEntityDTO, bool>> where = null,
            Func<IQueryable<TEntityDTO>, IOrderedQueryable<TEntityDTO>> orderBy = null,
            int? skip = null,
            int? take = null,
            List<Expression<Func<TEntityDTO, object>>> associations = null);

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
        IQueryable<TEntityDTO> Query(string where = null,
            object[] args = null,
            string orderBy = null,
            int? skip = null,
            int? take = null,
            string[] associations = null);

        /// <summary>
        /// Search.
        /// </summary>
        /// <param name="where">Where LINQ expression</param>
        /// <param name="orderBy">Order By LINQ expression</param>
        /// <param name="skip">Records to skip</param>
        /// <param name="take">Records to take</param>
        /// <param name="associations">Associations LINQ expression</param>
        /// <returns>IEnumerable</returns>
        IEnumerable<TEntityDTO> Search(Expression<Func<TEntityDTO, bool>> where = null,
            Func<IQueryable<TEntityDTO>, IOrderedQueryable<TEntityDTO>> orderBy = null,
            int? skip = null,
            int? take = null,
            List<Expression<Func<TEntityDTO, object>>> associations = null);

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
        IEnumerable<TEntityDTO> Search(string where = null,
            object[] args = null,
            string orderBy = null,
            int? skip = null,
            int? take = null,
            string[] associations = null);

        /// <summary>
        /// Select ALL.
        /// </summary>
        /// <returns>IEnumerable</returns>
        IEnumerable<TEntityDTO> SearchAll();

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
        /// <param name="entity">Entity DTO</param>
        /// <returns>Ok ?</returns>
        bool Update(ZOperationResult operationResult, TEntityDTO entity);

        #endregion Methods

        #region Methods *AndSave

        bool CreateAndSave(ZOperationResult operationResult, TEntityDTO entity);

        bool DeleteAndSave(ZOperationResult operationResult, TEntityDTO entity);

        bool UpdateAndSave(ZOperationResult operationResult, TEntityDTO entity);

        #endregion Methods *AndSave

        #region Triggers

        /// <summary>
        /// Before create Trigger.
        /// </summary>
        /// <param name="operationResult">Operation Result</param>
        /// <param name="entity">Entity DTO</param>
        /// <returns>Ok ?</returns>
        bool BeforeCreate(ZOperationResult operationResult, TEntityDTO entity);

        /// <summary>
        /// After create Trigger.
        /// </summary>
        /// <param name="operationResult">Operation Result</param>
        /// <param name="entity">Entity DTO</param>
        /// <returns>Ok ?</returns>
        bool AfterCreate(ZOperationResult operationResult, TEntityDTO entity);

        /// <summary>
        /// Before delete Trigger.
        /// </summary>
        /// <param name="operationResult">Operation Result</param>
        /// <param name="entity">Entity DTO</param>
        /// <returns>Ok ?</returns>
        bool BeforeDelete(ZOperationResult operationResult, TEntityDTO entity);

        /// <summary>
        /// After delete Trigger.
        /// </summary>
        /// <param name="operationResult">Operation Result</param>
        /// <param name="entity">Entity DTO</param>
        /// <returns>Ok ?</returns>
        bool AfterDelete(ZOperationResult operationResult, TEntityDTO entity);

        /// <summary>
        /// Before update Trigger.
        /// </summary>
        /// <param name="operationResult">Operation Result</param>
        /// <param name="entity">Entity DTO</param>
        /// <returns>Ok ?</returns>
        bool BeforeUpdate(ZOperationResult operationResult, TEntityDTO entity);

        /// <summary>
        /// After update Trigger.
        /// </summary>
        /// <param name="operationResult">Operation Result</param>
        /// <param name="entity">Entity DTO</param>
        /// <returns>Ok ?</returns>
        bool AfterUpdate(ZOperationResult operationResult, TEntityDTO entity);

        #endregion Triggers
    }
}