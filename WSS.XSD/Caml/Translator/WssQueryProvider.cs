using System.Linq;
using System.Linq.Expressions;

namespace Microsoft.Schemas.SharePoint.Caml
{
    public class WssQueryProvider<T>: IQueryProvider
    {
        public WssQueryProvider() { }

        IQueryable IQueryProvider.CreateQuery(Expression expression)
        {
            return new WssQuery<T>(this, expression);
        }

        IQueryable<TElement> IQueryProvider.CreateQuery<TElement>(Expression expression)
        {
            return new WssQuery<TElement>(this, expression);
        }

        object IQueryProvider.Execute(Expression expression)
        {
            return null;
        }

        TResult IQueryProvider.Execute<TResult>(Expression expression)
        {
            var isEnumerable = typeof(TResult).Name == "IEnumerable`1";
            return default(TResult);
        }
    }
}