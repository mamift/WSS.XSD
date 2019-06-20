using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Schemas.SharePoint;
using Microsoft.Schemas.SharePoint.Caml;
using NUnit.Framework;

namespace Tests
{
    public class CamlQueryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestViewDefinitionQuery()
        {
            var valueDefinition = new ValueDefinition {
                Untyped = XElement.Parse("<Value>Queensland</Value>")
            };

            var query = new Query() {
                Where = new LogicalJoinDefinition {
                    Eq = new List<LogicalTestDefinition> {
                        new LogicalTestDefinition {
                            FieldRef = new List<FieldRefDefinition> {
                                new FieldRefDefinition {Name = "State"}
                            },
                            Value = new List<ValueDefinition> {
                                valueDefinition
                            }
                        }
                    }
                }
            };

            var queryString = query.ToString();
            Assert.IsFalse(string.IsNullOrWhiteSpace(queryString));
            Assert.IsFalse(string.IsNullOrEmpty(queryString));
        }

        [Test]
        public void ReadViewDefinitionQueryTest()
        {
            Assert.DoesNotThrow(delegate {
                var queryString = "<Query> <Where> <Eq> <FieldRef Name=\"State\" /> <Value>Queensland</Value> </Eq> </Where> </Query>";
                
                var queryDef = Query.ChameleonParse(queryString);
                var _q = Query.Parse("<s:Query xmlns:s=\"http://schemas.microsoft.com/sharepoint/caml\"> <s:Where xmlns:s=\"http://schemas.microsoft.com/sharepoint/caml\"> " +
                                     "<s:Eq xmlns:s=\"http://schemas.microsoft.com/sharepoint/caml\" />" +
                                     "</s:Where> </s:Query>");

                Assert.IsNotNull(queryDef);
                Assert.IsNotNull(queryDef.Where);
                Assert.IsNotNull(queryDef.Where.Eq);
                Assert.IsTrue(queryDef.Where.Eq.Any());
            });
        }
    }
}