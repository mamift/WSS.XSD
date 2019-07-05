namespace Microsoft.Schemas.SharePoint.Caml
{
    public class WssListItem: IWssQueryableListItem
    {
        public string Title { get; set; }
        public int Id { get; }
    }
}