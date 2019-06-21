namespace Microsoft.Schemas.SharePoint
{
    public interface IWssQueryableListItem
    {
        string Title { get; set; }

        /// <summary>
        /// Usually the Id cannot be set.
        /// </summary>
        int Id { get; }
    }
}