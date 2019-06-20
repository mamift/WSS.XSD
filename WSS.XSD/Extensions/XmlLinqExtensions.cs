using System.Linq;
using System.Xml.Linq;

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
            if (el.Name.NamespaceName == string.Empty)
                el.Name = xmlns + el.Name.LocalName;
            foreach (var e in el.Elements())
                e.SetDefaultXmlNamespace(xmlns);
        }

        /// <summary>
        /// Returns a new <see cref="XElement"/> with the given <see cref="XNamespace"/> (<paramref name="xmlns"/>).
        /// <para>https://stackoverflow.com/questions/2874422/how-to-set-the-default-xml-namespace-for-an-xdocument</para>
        /// </summary>
        /// <param name="el"></param>
        /// <param name="xmlns"></param>
        /// <returns></returns>
        public static XElement WithDefaultXmlNamespace(this XElement el, XNamespace xmlns)
        {
            var name = string.IsNullOrWhiteSpace(el.Name.NamespaceName)
                ? xmlns + el.Name.LocalName
                : el.Name;

            return new XElement(name,
                from e in el.Elements()
                select e.WithDefaultXmlNamespace(xmlns));
        }
    }
}