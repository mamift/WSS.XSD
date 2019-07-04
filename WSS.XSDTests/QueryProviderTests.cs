using System.Linq;
using AgileObjects.ReadableExpressions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.Schemas.SharePoint;
using Microsoft.Schemas.SharePoint.Caml.Translator;
using NUnit.Framework;
using Remotion.Linq.Parsing.Structure;

namespace WSS.XSD.Tests
{
    [TestFixture]
    public class QueryProviderTests
    {
        [Test]
        public void Test()
        {
            var queryParser = QueryParser.CreateDefault();
            var context = new WssQuery<IWssQueryableListItem>(queryParser, new WssQueryExecutor());
            
            var query = context.Where(item => item.Id > 0 && string.IsNullOrWhiteSpace(item.Title));

            var exprString = query.Expression.ToReadableString();

            var csharpTree = CSharpSyntaxTree.ParseText(exprString);

            var list = query.ToList();
        }
    }
}