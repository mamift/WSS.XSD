using System.Linq;
using System.Xml.Linq;
using Microsoft.Schemas.SharePoint;
using Microsoft.Schemas.SharePoint.Caml;
using Microsoft.Schemas.SharePoint.Extensions;
using NUnit.Framework;
using Xml.Schema.Linq.Extensions;

namespace WSS.XSD.Tests
{
    public class CamlQueryTests
    {
        [Test]
        public void ValueDefinitionTest1()
        {
            var valueDefinition = new ValueDefinition {
                Untyped = XElement.Parse("<Value>Queensland </Value>"),
                XML = {"This is custom xml"}
            };

            Assert.IsTrue(valueDefinition.XML.Any());
            var first = valueDefinition.XML.First();
            Assert.IsTrue(first.IsNotEmpty());

            var camlString = valueDefinition.ToCamlString();

            Assert.IsTrue(camlString.IsNotEmpty());
            Assert.IsTrue(camlString.Contains("<Value>"));
            Assert.IsTrue(camlString.Contains("<XML>"));
        }

        [Test]
        public void ExampleCamlQueryEqValue()
        {
            var queryDef = new CamlQueryRoot {
                Where = new LogicalJoinDefinition {
                    And = {
                        new ExtendedLogicalJoinDefinition {
                            Eq = {
                                new LogicalTestDefinition {
                                    FieldRef = FieldRefDefinition.FromNames("State"),
                                    Value = ValueDefinition.NewTextValues("Queensland")
                                }
                            }
                        }
                    }
                }
            };

            queryDef.Where.And.First().Eq.Add(new LogicalTestDefinition {
                FieldRef = FieldRefDefinition.FromNames("Country"),
                Value = ValueDefinition.NewTextValues("Australia")
            });

            var query = new Query(queryDef);

            var queryString = query.ToString();
            var chameleonQueryString = queryDef.ToCamlString();

            Assert.IsTrue(queryString.IsNotEmpty());
            Assert.IsTrue(chameleonQueryString.IsNotEmpty());
        }
    }
}