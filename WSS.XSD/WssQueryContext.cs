using System.Linq.Expressions;

namespace Microsoft.Schemas.SharePoint
{
    public class WssQueryContext: IQueryContext
    {
        public object Execute(Expression expression, bool isEnumerable)
        {
            throw new System.NotImplementedException();
        }
    }
}