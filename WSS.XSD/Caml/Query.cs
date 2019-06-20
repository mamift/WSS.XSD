using System;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Schemas.SharePoint.Extensions;
using Xml.Schema.Linq;

namespace Microsoft.Schemas.SharePoint.Caml
{
    public partial class Query
    {
        /// <summary>
        /// Parse well formed XML, as string that may or may not have a default namespace necessary for typed XML validation.
        /// </summary>
        /// <param name="xmlString"></param>
        /// <returns></returns>
        public static Query ChameleonParse(string xmlString)
        {
            var xElement = XElement.Parse(xmlString);

            if (!xElement.HasAttributes) {
                // add default namespace attribute (for validation by the LinqToXsd type manager)
                var camlNs = XNamespace.Get("http://schemas.microsoft.com/sharepoint/caml");
                xElement.SetDefaultXmlNamespace(camlNs);
            }

            var typedXmlString = xElement.ToString();

            return Parse(typedXmlString);
        }
    }
}