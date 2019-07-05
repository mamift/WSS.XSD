using System.Collections.Generic;
using System.Linq;
using AgileObjects.NetStandardPolyfills;
using AgileObjects.ReadableExpressions;
using Remotion.Linq;
using Remotion.Linq.Clauses;

namespace Microsoft.Schemas.SharePoint.Caml
{
    public class WssCamlVisitor : QueryModelVisitorBase
    {
        private readonly string _sourceName;

        private List<string> _queryableFields = new List<string>();

        public override void VisitMainFromClause(MainFromClause fromClause, QueryModel queryModel)
        {
            var t = fromClause.FromExpression.ToReadableString();

            var queryableProps = fromClause.ItemType.GetPublicInstanceProperties();
            _queryableFields.AddRange(queryableProps.Select(p => p.Name));
            
            base.VisitMainFromClause(fromClause, queryModel);
        }

        public override void VisitWhereClause(WhereClause whereClause, QueryModel queryModel, int index)
        {
            base.VisitWhereClause(whereClause, queryModel, index);
        }
    }
}