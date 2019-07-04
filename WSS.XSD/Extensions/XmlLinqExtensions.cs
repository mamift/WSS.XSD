using System.Xml.Linq;
using Xml.Schema.Linq;

namespace Microsoft.Schemas.SharePoint.Extensions
{
    public static class XmlLinqExtensions
    {
        /// <summary>
        /// Changes the default namespace for the current <see cref="XElement"/>.
        /// <para>https://stackoverflow.com/questions/2874422/how-to-set-the-default-xml-namespace-for-an-xdocument</para>
        /// </summary>
        /// <param name="el"></param>
        /// <param name="xmlns"></param>
        public static void SetDefaultXmlNamespace(this XElement el, XNamespace xmlns)
        {
            if (string.IsNullOrWhiteSpace(el.Name.NamespaceName))
                el.Name = xmlns + el.Name.LocalName;
            foreach (var e in el.Elements())
                e.SetDefaultXmlNamespace(xmlns);
        }

        /// <summary>
        /// Removes any and all namespaces present on the current <paramref name="el"/> and children.
        /// </summary>
        /// <param name="el"></param>
        public static void RemoveXmlns(this XElement el)
        {
            if (!string.IsNullOrWhiteSpace(el.Name.NamespaceName))
                el.Name = el.Name.LocalName;
            foreach (var e in el.Elements())
                e.RemoveXmlns();
        }

        /// <summary>
        /// Returns the XML element as a string without namespace declarations.
        /// </summary>
        /// <param name="xTypedElement"></param>
        /// <returns></returns>
        public static string ToCamlString(this XTypedElement xTypedElement)
        {
            xTypedElement.Untyped.RemoveXmlns();

            return xTypedElement.Untyped.ToString(SaveOptions.OmitDuplicateNamespaces);
        }
    }
}