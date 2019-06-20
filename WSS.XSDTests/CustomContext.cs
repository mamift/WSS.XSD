using System;
using System.Linq.Expressions;
using Microsoft.Schemas.SharePoint;

namespace Tests
{
    public class CustomContext: IQueryContext
    {
        public object Execute(Expression expression, bool isEnumerable)
        {
            var returnType = expression.Type;
            var nodeType = expression.NodeType;
            
            throw new System.NotImplementedException(nameof(Execute));
        }
    }
}