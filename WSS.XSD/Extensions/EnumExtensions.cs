using System;
using System.Linq;
using Microsoft.Schemas.SharePoint.Internal;

namespace Microsoft.Schemas.SharePoint.Extensions
{
    public static class EnumExtensions
    {
        public static T GetAttribute<T>(this Enum enumValue) where T : Attribute
        {
            var type = enumValue.GetType();
            var memberInfo = type.GetMember(enumValue.ToString());
            var member = memberInfo.FirstOrDefault(m => m.DeclaringType == type);
            var attribute = Attribute.GetCustomAttribute(member ?? throw new NullReferenceException(), typeof(T), false);
            return attribute is T theAttribute ? theAttribute : null;
        }
        
        /// <summary>
        /// Get's the string value associated with this enum (set via the <see cref="StringValueAttribute"/>).
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static string StringValue(this Enum enumerable)
        {
            return enumerable.GetAttribute<StringValueAttribute>().StringValue;
        }
    }
}