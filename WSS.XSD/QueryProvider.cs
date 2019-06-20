using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Microsoft.Schemas.SharePoint
{
    public class QueryProvider : IQueryProvider
    {
        private readonly IQueryContext QueryContext;

        public QueryProvider(IQueryContext queryContext)
        {
            this.QueryContext = queryContext;
        }

        public virtual IQueryable CreateQuery(Expression expression)
        {
            var elementType = TypeSystem.GetElementType(expression.Type);
            return (IQueryable)Activator.CreateInstance(typeof(Queryable<>).
                    MakeGenericType(elementType), this, expression);
        }

        public virtual IQueryable<T> CreateQuery<T>(Expression expression)
        {
            return new Queryable<T>(this, expression);
        }

        object IQueryProvider.Execute(Expression expression)
        {
            return QueryContext.Execute(expression, false);
        }

        T IQueryProvider.Execute<T>(Expression expression)
        {
            var isEnumerable = typeof(T).Name == "IEnumerable`1";
            return (T)QueryContext.Execute(expression, isEnumerable);
        }
    }
}