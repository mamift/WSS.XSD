using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Schemas.SharePoint
{
    public partial class FieldRefDefinition
    {
        /// <summary>
        /// Create new instances from given field names.
        /// </summary>
        /// <param name="names"></param>
        /// <returns></returns>
        public static List<FieldRefDefinition> FromNames(params string[] names)
        {
            return names.Select(n => new FieldRefDefinition { Name = n }).ToList();
        }

        /// <summary>
        /// Create a new instance from a given name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static FieldRefDefinition FromName(string name)
        {
            return new FieldRefDefinition { Name = name };
        }
    }
}