namespace Microsoft.Schemas.SharePoint
{
    public class WssListItem: IWssQueryableListItem
    {
        public string Title { get; set; }
        public int Id { get; }
    }
}