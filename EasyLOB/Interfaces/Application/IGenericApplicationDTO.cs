using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EasyLOB
{
    public interface IGenericApplicationDTO<TEntityDTO, TEntity> : IGenericApplication<TEntity>
        where TEntityDTO : class, IZDTOBase<TEntityDTO, TEntity>
        where TEntity : class, IZDataBase
    {
        #region Methods

        bool Create(ZOperationResult operationResult, TEntityDTO entityDTO);

        bool Delete(ZOperationResult operationResult, TEntityDTO entityDTO);

        new TEntityDTO Get(ZOperationResult operationResult, Expression<Func<TEntity, bool>> where);

        new TEntityDTO Get(ZOperationResult operationResult, string where, object[] args = null);

        new TEntityDTO GetById(ZOperationResult operationResult, object id);

        new TEntityDTO GetById(ZOperationResult operationResult, object[] ids);

        object[] GetIds(TEntityDTO entityDTO);

        new IEnumerable<TEntityDTO> Search(ZOperationResult operationResult,
            Expression<Func<TEntity, bool>> where = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null,
            List<Expression<Func<TEntity, object>>> associations = null);

        new IEnumerable<TEntityDTO> Search(ZOperationResult operationResult,
            string where = null,
            object[] args = null,
            string orderBy = null,
            int? skip = null,
            int? take = null,
            List<string> associations = null);

        new IEnumerable<TEntityDTO> SearchAll(ZOperationResult operationResult);

        bool Update(ZOperationResult operationResult, TEntityDTO entityDTO);

        #endregion Methods
    }
}