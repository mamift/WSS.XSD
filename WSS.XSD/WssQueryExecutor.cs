using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Remotion.Linq;
using Remotion.Linq.Clauses;
using Remotion.Linq.Clauses.ExpressionVisitors;

namespace Microsoft.Schemas.SharePoint
{
    public class WssQueryExecutor: IQueryExecutor
    {
        // Set up a property that will hold the current item being enumerated.
        public IWssQueryableListItem Current { get; private set; }

        public IEnumerable<T> ExecuteCollection<T>(QueryModel queryModel)
        {
            // Create an expression that returns the current item when invoked.
            Expression currentItemExpression = Expression.Property(Expression.Constant(this), nameof(Current));

            // Now replace references like the "i" in "select i" that refers to the "i" in "from i in items"
            var mapping = new QuerySourceMapping();
            mapping.AddMapping(queryModel.MainFromClause, currentItemExpression);
            queryModel.TransformExpressions(e => ReferenceReplacingExpressionVisitor.ReplaceClauseReferences(e, mapping, true));

            // Create a lambda that takes our SampleDataSourceItem and passes it through the select clause
            // to produce a type of T.  (T may be SampleDataSourceItem, in which case this is an identity function.)
            var currentItemProperty = Expression.Parameter(typeof(IWssQueryableListItem));
            var projection = Expression.Lambda<Func<IWssQueryableListItem, T>>(queryModel.SelectClause.Selector, currentItemProperty);
            var projector = projection.Compile();

            var whereClause = queryModel.BodyClauses.OfType<WhereClause>().FirstOrDefault();
            if (whereClause != null) {
                var wherePredicate = whereClause.Predicate;
                var whereFilter =
                    Expression.Lambda<Func<IWssQueryableListItem, bool>>(wherePredicate, true,
                        new List<ParameterExpression>() {  });
            }

            // Pretend we're getting SampleDataSourceItems from somewhere...
            for (var i = 0; i < 10; i++)
            {
                // Set the current item so currentItemExpression can access it.
                Current = new WssListItem();

                // Use the projector to convert (if necessary) the current item to what is being selected and return it.
                yield return projector(Current);
            }
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