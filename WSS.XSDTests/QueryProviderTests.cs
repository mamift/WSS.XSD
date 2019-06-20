using System.Linq;
using Microsoft.Schemas.SharePoint;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class QueryProviderTests
    {
        [Test]
        public void Test()
        {
            var ctx = new Queryable<string>(new CustomContext());

            var query = from s in ctx where s.StartsWith("T") select s;

            var list = query.ToList();
        }
    }
}