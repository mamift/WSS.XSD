using System;

namespace Microsoft.Schemas.SharePoint.Internal
{
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Class | AttributeTargets.Field | AttributeTargets.Property)]
    public class StringValueAttribute: Attribute
    {
        public StringValueAttribute(string stringValue)
        {
            StringValue = stringValue;
        }

        public string StringValue { get; set; }
    }
}