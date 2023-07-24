namespace Nobi.Base.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// Defines the <see cref="ExpressionsHelper" />.
    /// </summary>
    public static class ExpressionsHelper
    {
        #region Methods

        public static Expression<Func<TEntity, bool>> CreatePredicate<TEntity>(this object predicateObject)
        {
            var parameterExpression = Expression.Parameter(typeof(TEntity), "item");
            Expression memberExpression = parameterExpression;
            var objectDictionary = MakeDictionary(predicateObject);
            foreach (var entry in objectDictionary.Where(entry => typeof(TEntity).GetProperty(entry.Key) == null))
            {
                throw new ArgumentException(string.Format("Type {0} has no property {1}", typeof(TEntity).Name, entry.Key));
            }
            var equalityExpressions = GetBinaryExpressions(objectDictionary, memberExpression).ToList();
            var body = equalityExpressions.First();
            body = equalityExpressions.Skip(1).Aggregate(body, Expression.And);

            return Expression.Lambda<Func<TEntity, bool>>(body, new[] { parameterExpression });
        }

        private static IEnumerable<BinaryExpression> GetBinaryExpressions(IDictionary<string, object> dic, Expression expression)
        {
            return dic.Select(m => Expression.Equal(Expression.Property(expression, m.Key), Expression.Constant(m.Value)));
        }

        private static IDictionary<string, object> MakeDictionary(object withProperties)
        {
            var properties = TypeDescriptor.GetProperties(withProperties);
            return properties.Cast<PropertyDescriptor>().ToDictionary(property => property.Name, property => property.GetValue(withProperties));
        }
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> a, Expression<Func<T, bool>> b)
        {

            ParameterExpression p = a.Parameters[0];

            SubstExpressionVisitor visitor = new SubstExpressionVisitor();
            visitor.subst[b.Parameters[0]] = p;

            Expression body = Expression.AndAlso(a.Body, visitor.Visit(b.Body));
            return Expression.Lambda<Func<T, bool>>(body, p);
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> a, Expression<Func<T, bool>> b)
        {

            ParameterExpression p = a.Parameters[0];

            SubstExpressionVisitor visitor = new SubstExpressionVisitor();
            visitor.subst[b.Parameters[0]] = p;

            Expression body = Expression.OrElse(a.Body, visitor.Visit(b.Body));
            return Expression.Lambda<Func<T, bool>>(body, p);
        }
        internal class SubstExpressionVisitor : ExpressionVisitor
        {
            public Dictionary<Expression, Expression> subst = new Dictionary<Expression, Expression>();

            protected override Expression VisitParameter(ParameterExpression node)
            {
                Expression newValue;
                if (subst.TryGetValue(node, out newValue))
                {
                    return newValue;
                }
                return node;
            }
        }
        #endregion Methods
    }
}