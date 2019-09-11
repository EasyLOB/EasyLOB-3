using System;
using System.Collections.Generic;
using System.Linq.Expressions;

// Expression.Property Method
// https://msdn.microsoft.com/en-us/library/system.linq.expressions.expression.property%28v=vs.110%29.aspx

namespace EasyLOB.Library
{
    public static partial class LambdaHelper<TEntity>
    {
        #region Methods

        public static Expression<Func<TEntity, object>> ToFuncProperty(string property)
        {
            var parameterExpression = Expression.Parameter(typeof(TEntity), "x");

            var memberExpression = Expression.Property(parameterExpression, property);

            var lambda = Expression.Lambda<Func<TEntity, object>>(memberExpression, parameterExpression);

            return lambda;
        }

        public static List<Expression<Func<TEntity, object>>> ToFuncProperty(string[] properties)
        {
            List<Expression<Func<TEntity, object>>> expressions = new List<Expression<Func<TEntity, object>>>();

            foreach (string property in properties)
            {
                expressions.Add(ToFuncProperty(property));
            }

            return expressions;
        }

        #endregion Methods
    }
}