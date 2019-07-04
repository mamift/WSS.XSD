using System;
using System.Collections.Generic;
using System.Linq;
using AgileObjects.ReadableExpressions;
using Microsoft.CodeAnalysis.CSharp;
using Remotion.Linq;
using Remotion.Linq.Clauses;

namespace Microsoft.Schemas.SharePoint.Caml.Translator
{
    public class WssQueryExecutor : IQueryExecutor
    {
        // Set up a property that will hold the current item being enumerated.
        public IWssQueryableListItem Current { get; private set; }

        public IEnumerable<T> ExecuteCollection<T>(QueryModel queryModel)
        {
            var mapping = new QuerySourceMapping();
            queryModel.Accept(new WssCamlVisitor());

            var selectorExpr = queryModel.SelectClause.Selector;
            var fromExpr = queryModel.MainFromClause.FromExpression;
            var bodyExprs = queryModel.BodyClauses.OfType<WhereClause>().ToList();

            var fromItem = queryModel.MainFromClause.ItemName;
            var fromSource = fromExpr.ToReadableString();
            var selectorString = selectorExpr.ToReadableString();
            var bcStrings = bodyExprs.Select(bc => bc.Predicate.ToReadableString());

            var syntaxTree = CSharpSyntaxTree.ParseText(fromSource);

            yield return default(T);
        }

        public T ExecuteSingle<T>(QueryModel queryModel, bool returnDefaultWhenEmpty)
        {
            var sequence = ExecuteCollection<T>(queryModel);

            return returnDefaultWhenEmpty ? sequence.SingleOrDefault() : sequence.Single();
        }

        public T ExecuteScalar<T>(QueryModel queryModel)
        {
            // We'll get to this one later...
            throw new NotImplementedException();
        }
    }
}