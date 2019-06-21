using System.Linq;
using Microsoft.Schemas.SharePoint;
using NUnit.Framework;
using Remotion.Linq.Parsing.Structure;

namespace Tests
{
    [TestFixture]
    public class QueryProviderTests
    {
        [Test]
        public void Test()
        {
            var queryParser = QueryParser.CreateDefault();
            var context = new WssQuery<IWssQueryableListItem>(queryParser, new WssQueryExecutor());
            
            var query = from s in context where s.Id > 0 select s;

            var list = query.ToList();
        }
    }
}