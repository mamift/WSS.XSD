using System.Linq;
using System.Linq.Expressions;
using Remotion.Linq;
using Remotion.Linq.Parsing.Structure;

namespace Microsoft.Schemas.SharePoint.Caml
{
    public class WssQuery<T> : QueryableBase<T>
    {
        public WssQuery(IQueryParser queryParser, IQueryExecutor executor) : base(queryParser, executor) { }

        public WssQuery(IQueryProvider provider) : base(provider) { }

        public WssQuery(IQueryProvider provider, Expression expression) : base(provider, expression) { }
    }

    public class WssQueryContext
    {
        public WssQueryContext()
        {

        }
    }
}