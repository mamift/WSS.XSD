using System.Collections.Generic;
using System.Xml.Linq;
using Microsoft.Schemas.SharePoint;
using Microsoft.Schemas.SharePoint.Caml;
using NUnit.Framework;

namespace Tests
{
    public class WssXsdTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestViewDefinitionQuery()
        {
            var valueDefinition = new ValueDefinition {
                Untyped = XElement.Parse("<Value>Queensland </Value>"),
                XML = new List<string>() { "<XML>This is custom xml</XML>" }
            };

            var empty = new EmptyQueryDefinition();

            var queryDef = new CamlQueryRoot {
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

            var query = new Query(queryDef);

            var queryString = query.ToString();

            Assert.IsFalse(string.IsNullOrWhiteSpace(queryString));
            Assert.IsFalse(string.IsNullOrEmpty(queryString));
        }
    }
}