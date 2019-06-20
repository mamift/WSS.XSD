using System.Linq.Expressions;

namespace Microsoft.Schemas.SharePoint
{
    public interface IQueryContext
    {
        object Execute(Expression expression, bool isEnumerable);
    }
}