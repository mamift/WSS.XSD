using Microsoft.Schemas.SharePoint;
using Microsoft.Schemas.SharePoint.Extensions;
using NUnit.Framework;
using Xml.Schema.Linq.Extensions;

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
    }
}