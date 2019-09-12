using System.Linq;
using Microsoft.Schemas.SharePoint.Caml;
using Microsoft.Schemas.SharePoint.Extensions;
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

            var camlVersion = query.ToCamlTree();

            var list = query.ToList();
        }
    }
}