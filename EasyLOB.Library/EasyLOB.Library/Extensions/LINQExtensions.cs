using System;
using System.Collections.Generic;
using System.Linq.Expressions;

// Append to an expression
// http://stackoverflow.com/questions/2231302/append-to-an-expression

namespace EasyLOB.Library
{
    /*
    public static class LINQExtensions
    {
        #region Methods

        public static Expression<Func<TInput, bool>> CombineWithAndAlso<TInput>(this Expression<Func<TInput, bool>> func1,
            Expression<Func<TInput, bool>> func2)
            where TInput : class, IZDataBase
        {
            return Expression.Lambda<Func<TInput, bool>>(
                Expression.AndAlso(func1.Body, new ExpressionParameterReplacer(func2.Parameters, func1.Parameters).Visit(func2.Body)),
                func1.Parameters);
        }

        public static Expression<Func<TInput, bool>> CombineWithOrElse<TInput>(this Expression<Func<TInput, bool>> func1,
            Expression<Func<TInput, bool>> func2)
            where TInput : class, IZDataBase
        {
            return Expression.Lambda<Func<TInput, bool>>(
                Expression.AndAlso(func1.Body, new ExpressionParameterReplacer(func2.Parameters, func1.Parameters).Visit(func2.Body)),
                func1.Parameters);
        }

        #endregion Methods
    }
    */
    public class ExpressionParameterReplacer : ExpressionVisitor
    {
        #region Properties

        private IDictionary<ParameterExpression, ParameterExpression> ParameterReplacements { get; set; }

        #endregion Properties

        #region Methods

        public ExpressionParameterReplacer(IList<ParameterExpression> fromParameters, IList<ParameterExpression> toParameters)
        {
            ParameterReplacements = new Dictionary<ParameterExpression, ParameterExpression>();
            for (int i = 0; i != fromParameters.Count && i != toParameters.Count; i++)
            {
                ParameterReplacements.Add(fromParameters[i], toParameters[i]);
            }
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            ParameterExpression replacement;
            if (ParameterReplacements.TryGetValue(node, out replacement))
            {
                node = replacement;
            }

            return base.VisitParameter(node);
        }

        #endregion Methods
    }
}