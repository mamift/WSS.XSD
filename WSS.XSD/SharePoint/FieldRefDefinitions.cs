namespace Microsoft.Schemas.SharePoint
{
    public partial class FieldRefDefinitions
    {
        public static FieldRefDefinitions FromNames(params string[] names)
        {
            return new FieldRefDefinitions {
                FieldRef = FieldRefDefinition.FromNames(names)
            };
        }
    }
}