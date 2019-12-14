using EasyLOB.Data;
using EasyLOB.Library;
using Microsoft.OData.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace EasyLOB.Persistence
{
    public abstract class GenericRepositoryOData<TEntityDTO, TEntity> : IGenericRepositoryDTO<TEntityDTO, TEntity>
        where TEntityDTO : class, IZDTOBase<TEntityDTO, TEntity>
        where TEntity : class, IZDataBase
    {
        #region Properties

        public virtual IZProfile Profile
        {
            get
            {
                Type type = this.GetRepositoryType<TEntityDTO, TEntity>();

                return DataHelper.GetProfile(type);
            }
        }

        public virtual string Entity
        {
            get { return typeof(TEntity).Name; }
        }

        public virtual int Joins
        {
            get { return 10; }
        }

        public IUnitOfWorkDTO UnitOfWork { get; }

        #endregion Properties

        #region Properties OData

        public DataServiceContext Container { get; protected set; }

        public DataServiceQuery DataServiceQuery
        {
            get { return Container.CreateQuery<TEntityDTO>(EntitySetName); }
        }

        public string EntitySetName
        {
            // EntityDTO => Entity
            get { return Regex.Replace(typeof(TEntityDTO).Name, @"DTO$", String.Empty); }
            //get { return typeof(TEntityDTO).Name.Replace("DTO", ""); }
        }

        #endregion Properties OData

        #region Methods

        public GenericRepositoryOData(IUnitOfWorkDTO unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public virtual int Count(Expression<Func<TEntityDTO, bool>> where)
        {
            int result;

            Filter(where);

            if (where != null)
            {
                result = Query().Count(where);
            }
            else
            {
                result = DataServiceQuery.Count();
            }

            return result;
        }

        public virtual int Count(string where, object[] args = null)
        {
            int result;

            Filter(ref where, ref args);

            if (!String.IsNullOrEmpty(where))
            {
                if (args != null)
                {
                    result = Query().Where(where, args).Count();
                }
                else
                {
                    result = Query().Where(where).Count();
                }
            }
            else
            {
                result = DataServiceQuery.Count();
            }

            return result;
        }

        public virtual int CountAll()
        {
            return Query().Count();
        }

        public virtual bool Create(ZOperationResult operationResult, TEntityDTO entity)
        {
            try
            {
                if (BeforeCreate(operationResult, entity))
                {
                    //if (UnitOfWork.BeforeCreate(operationResult, entity))
                    {
                        Container.AddObject(EntitySetName, entity);

                        AfterCreate(operationResult, entity);
                        //{
                        //    UnitOfWork.AfterCreate(operationResult, entity);
                        //}
                    }
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseExceptionOData(exception);
            }

            return operationResult.Ok;
        }

        public virtual bool Delete(ZOperationResult operationResult, TEntityDTO entity)
        {
            try
            {
                if (BeforeDelete(operationResult, entity))
                {
                    //if (UnitOfWork.BeforeDelete(operationResult, entity))
                    {
                        Container.DeleteObject(entity);

                        AfterDelete(operationResult, entity);
                        //{
                        //    UnitOfWork.AfterDelete(operationResult, entity);
                        //}
                    }
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseExceptionOData(exception);
            }

            return operationResult.Ok;
        }

        public virtual void Filter(Expression<Func<TEntityDTO, bool>> where)
        {
        }

        public virtual void Filter(ref string where, ref object[] args)
        {
            if (args != null)
            {
                // DateTime
                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i] is string)
                    {
                        // "2000-01-01T23:59:59.999Z"
                        Regex regex = new Regex(@"[0-2][0-9][0-9][0-9]-[0-1][0-9]-[0-3][0-9]T[0-2][0-9]:[0-5][0-9]:[0-5][0-9].[0-9][0-9][0-9]Z");
                        Match match = regex.Match(args[i] as string);
                        if (match.Success)
                        {
                            args[i] = DateTime.ParseExact(args[i] as string, "yyyy-MM-ddTHH:mm:ss.fffZ",
                                System.Globalization.CultureInfo.InvariantCulture).Date;
                        }
                    }
                }
            }
        }

        public virtual TEntityDTO Get(Expression<Func<TEntityDTO, bool>> where)
        {
            Filter(where);

            return Query().Where(where).FirstOrDefault();
        }

        public virtual TEntityDTO Get(string where, object[] args = null)
        {
            Filter(ref where, ref args);

            return Query().Where(where).FirstOrDefault();
        }

        public virtual TEntityDTO GetById(object id)
        {
            return GetById(new object[] { id });
        }

        public virtual TEntityDTO GetById(object[] ids)
        {
            string predicate = Profile.LINQWhere;
            Expression<Func<TEntityDTO, bool>> where =
                System.Linq.Dynamic.DynamicExpression.ParseLambda<TEntityDTO, bool>(predicate, ids);

            return Get(where);
        }

        public virtual object[] GetIds(TEntityDTO entityDTO)
        {
            List<object> ids = new List<object>();

            foreach (string key in Profile.Keys)
            {
                ids.Add(LibraryHelper.GetPropertyValue(entityDTO, key));
            }

            return ids.ToArray();
        }

        public virtual object GetNextSequence()
        {
            return null;
        }

        public virtual void Join(TEntityDTO entity)
        {
        }

        public virtual void Join(IEnumerable<TEntityDTO> enumerable)
        {
            if (enumerable != null)
            {
                int items = 0;
                foreach (TEntityDTO entity in enumerable)
                {
                    Join(entity);

                    if (++items >= Joins)
                    {
                        break;
                    }
                }
            }
        }

        public virtual IQueryable<TEntityDTO> Join(IQueryable<TEntityDTO> query)
        {
            return query;
        }

        public virtual IQueryable<TEntityDTO> Join(IQueryable<TEntityDTO> query, List<Expression<Func<TEntityDTO, object>>> associations)
        {
            return Join(query);
        }

        public virtual IQueryable<TEntityDTO> Join(IQueryable<TEntityDTO> query, string[] associations)
        {
            return Join(query);
        }

        public virtual IQueryable<TEntityDTO> Query()
        {
            IQueryable<TEntityDTO> query = Container.CreateQuery<TEntityDTO>(EntitySetName).AsQueryable<TEntityDTO>();
            query = Join(query);

            return query;
        }

        public virtual IQueryable<TEntityDTO> Query(Expression<Func<TEntityDTO, bool>> where = null,
            Func<IQueryable<TEntityDTO>, IOrderedQueryable<TEntityDTO>> orderBy = null,
            int? skip = null,
            int? take = null,
            List<Expression<Func<TEntityDTO, object>>> associations = null)
        {
            IQueryable<TEntityDTO> query = Container.CreateQuery<TEntityDTO>(EntitySetName).AsQueryable<TEntityDTO>();

            Filter(where);

            if (where != null)
            {
                query = query.Where(where);
            }

            if (skip != null && orderBy == null)
            {
                query = query.OrderBy(Profile.LINQOrderBy);
            }
            else if (orderBy != null)
            {
                query = orderBy(query);
            }

            // The method 'Skip' is only supported for sorted input in LINQ to Entities.
            // The method 'OrderBy' must be called before the method 'Skip'.
            if (skip != null && skip >= 0)
            {
                query = query.Skip((int)skip);
            }

            if (take != null && take > 0)
            {
                query = query.Take((int)take);
            }

            //query = Join(query, associations);

            return query;
        }

        public virtual IQueryable<TEntityDTO> Query(string where = null,
            object[] args = null,
            string orderBy = null,
            int? skip = null,
            int? take = null,
            string[] associations = null)
        {
            IQueryable<TEntityDTO> query = Container.CreateQuery<TEntityDTO>(EntitySetName).AsQueryable<TEntityDTO>();

            Filter(ref where, ref args);

            if (!String.IsNullOrEmpty(where))
            {
                if (args != null)
                {
                    query = query.Where(where, args);
                }
                else
                {
                    query = query.Where(where);
                }
            }

            //if (orderBy != null && orderBy.Contains("LookupText"))
            //{
            //    orderBy = null;
            //}

            if (skip != null && String.IsNullOrEmpty(orderBy))
            {
                query = query.OrderBy(Profile.LINQOrderBy);
            }
            else if (!String.IsNullOrEmpty(orderBy))
            {
                query = query.OrderBy(orderBy);
            }

            // The method 'Skip' is only supported for sorted input in LINQ to Entities.
            // The method 'OrderBy' must be called before the method 'Skip'.
            if (skip != null && skip >= 0)
            {
                query = query.Skip((int)skip);
            }

            if (take != null && take > 0)
            {
                query = query.Take((int)take);
            }

            //query = Join(query, associations);

            return query;
        }

        public virtual IEnumerable<TEntityDTO> Search(Expression<Func<TEntityDTO, bool>> where = null,
            Func<IQueryable<TEntityDTO>, IOrderedQueryable<TEntityDTO>> orderBy = null,
            int? skip = null,
            int? take = null,
            List<Expression<Func<TEntityDTO, object>>> associations = null)
        {
            IQueryable<TEntityDTO> query = Query(where, orderBy, skip, take, associations);
            query = Join(query, associations);

            return query.ToList<TEntityDTO>();
        }

        public virtual IEnumerable<TEntityDTO> Search(string where = null,
            object[] args = null,
            string orderBy = null,
            int? skip = null,
            int? take = null,
            string[] associations = null)
        {
            IQueryable<TEntityDTO> query = Query(where, args, orderBy, skip, take, associations);
            query = Join(query, associations);

            return query.ToList<TEntityDTO>();
        }

        public virtual IEnumerable<TEntityDTO> SearchAll()
        {
            return Query().ToList();
        }

        public virtual void SetSequence(int value)
        {
        }

        public virtual bool Update(ZOperationResult operationResult, TEntityDTO entity)
        {
            try
            {
                if (BeforeUpdate(operationResult, entity))
                {
                    //if (UnitOfWork.BeforeUpdate(operationResult, entity))
                    {
                        Container.UpdateObject(entity);

                        AfterUpdate(operationResult, entity);
                        //{
                        //    UnitOfWork.AfterUpdate(operationResult, entity);
                        //}
                    }
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseExceptionOData(exception);
            }

            return operationResult.Ok;
        }

        #endregion Methods

        #region Methods *AndSave

        public bool CreateAndSave(ZOperationResult operationResult, TEntityDTO entity)
        {
            if (Create(operationResult, entity))
            {
                UnitOfWork.Save(operationResult);
            }

            return operationResult.Ok;
        }

        public bool DeleteAndSave(ZOperationResult operationResult, TEntityDTO entity)
        {
            if (Delete(operationResult, entity))
            {
                UnitOfWork.Save(operationResult);
            }

            return operationResult.Ok;
        }

        public bool UpdateAndSave(ZOperationResult operationResult, TEntityDTO entity)
        {
            if (Update(operationResult, entity))
            {
                UnitOfWork.Save(operationResult);
            }

            return operationResult.Ok;
        }

        #endregion Methods *AndSave

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

        public virtual bool BeforeCreate(ZOperationResult operationResult, TEntityDTO entity)
        {
            return operationResult.Ok;
        }

        public virtual bool AfterCreate(ZOperationResult operationResult, TEntityDTO entity)
        {
            return operationResult.Ok;
        }

        public virtual bool BeforeDelete(ZOperationResult operationResult, TEntityDTO entity)
        {
            return operationResult.Ok;
        }

        public virtual bool AfterDelete(ZOperationResult operationResult, TEntityDTO entity)
        {
            return operationResult.Ok;
        }

        public virtual bool BeforeUpdate(ZOperationResult operationResult, TEntityDTO entity)
        {
            return operationResult.Ok;
        }

        public virtual bool AfterUpdate(ZOperationResult operationResult, TEntityDTO entity)
        {
            return operationResult.Ok;
        }

        #endregion Triggers
    }
}