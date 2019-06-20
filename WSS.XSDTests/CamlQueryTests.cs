using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Schemas.SharePoint;
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

            var t = new ViewDefinition {
                Untyped = XElement.Parse("<View> </View>"),
                Query = new CamlQueryRoot {
                    Where = new LogicalJoinDefinition {
                        Eq = new List<LogicalTestDefinition> {
                            new LogicalTestDefinition {
                                FieldRef = new List<FieldRefDefinition> {
                                    new FieldRefDefinition { Name = "State" }
                                },
                                Value = new List<ValueDefinition> {
                                    valueDefinition
                                }
                            }
                        }
                    }
                }
            };

            var tString = t.ToString();
            Assert.Pass();
        }

        [Test]
        public void ReadViewDefinitionQueryTest()
        {
            Assert.DoesNotThrow(delegate {
                var queryString = "<View> <Query> <Where> <Eq> <FieldRef Name=\"State\" /> <Value>Queensland</Value> </Eq> </Where> </Query> </View>";
                
                var queryDef = new ViewDefinition {
                    Query = new CamlQueryRoot() {
                        
                    }
                };

                Assert.IsNotNull(queryDef.Query);
                Assert.IsNotNull(queryDef.Query.Where);
                Assert.IsNotNull(queryDef.Query.Where.Eq);
                Assert.IsTrue(queryDef.Query.Where.Eq.Any());
            });
        }
    }
}