namespace Microsoft.Schemas.SharePoint.Caml
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