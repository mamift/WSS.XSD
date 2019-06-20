using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Microsoft.Schemas.SharePoint
{
    public class WssQuery<T> : IOrderedQueryable<T>
    {
        private Type _elementType;
        private Expression _expression;
        private IQueryProvider _provider;

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) _provider.Execute(_expression)).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return ((IEnumerable<T>)_provider.Execute(_expression)).GetEnumerator();
        }

        Type IQueryable.ElementType => _elementType;

        Expression IQueryable.Expression => _expression;

        IQueryProvider IQueryable.Provider => _provider;

        public WssQuery(IQueryProvider provider)
        {
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }

        public WssQuery(IQueryProvider provider, Expression expression)
        {
            _expression = expression ?? throw new ArgumentNullException(nameof(expression));
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }
    }
}