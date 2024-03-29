using System;
using System.Collections.Generic;
using Microsoft.Schemas.SharePoint;
using Microsoft.Schemas.SharePoint.Caml;
using Microsoft.Schemas.SharePoint.Extensions;
using NUnit.Framework;
using Xml.Schema.Linq.Extensions;
using List = Microsoft.Schemas.SharePoint.List;

namespace WSS.XSD.Tests
{
    public class WssXsdTests
    {
        [Test]
        public void TestViewDefinitionQuery()
        {
            var fieldRefDefinitions = FieldRefDefinitions.FromNames("Id", "Title", "Date Modified", "Date Created");

            var viewDef = new ViewDefinition {
                List = 1,
                DisplayName = "Common fields view",
                ViewFields = fieldRefDefinitions,
                Query = new CamlQueryRoot {
                    Where = new LogicalJoinDefinition {
                        BeginsWith = {
                            new LogicalTestDefinition {
                                FieldRef = { fieldRefDefinitions.FieldRef[1] },
                                Value = { ValueDefinition.NewTextValue("Anti-") }
                            }
                        }
                    }
                }
            };

            var caml = viewDef.ToCamlString();

            Assert.IsTrue(caml.IsNotEmpty());
        }

        [Test]
        public void ListSchemaTest()
        {
            var xml = List.Load(@"SitePagesSchema.xml");

            Assert.IsNotNull(xml);

            Assert.IsNotNull(xml.Name);
            var guid = Guid.Parse(xml.Name);
            Assert.IsNotNull(guid);

            Assert.IsTrue(xml.Title == "Site Pages");
        }

        [Test]
        public void JoinTest()
        {
            var joins = new Joins {
                Join = {
                    new Join {
                        Eq = new EqType {
                            FieldRef = {
                                new FieldRef {
                                    Name = "CapitalCity",
                                    RefType = "Text"
                                },
                                new FieldRef {
                                    Name = "ReferencedCity",
                                    RefType = "Text"
                                }
                            }
                        }
                    }
                }
            };

            var str = joins.ToCamlString();

            Assert.IsNotNull(str);
        }
    }
}