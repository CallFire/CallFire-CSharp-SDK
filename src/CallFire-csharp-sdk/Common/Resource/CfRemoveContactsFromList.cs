namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfRemoveContactsFromList
    {
        public CfRemoveContactsFromList(long contactListId, object item)
        {
            ContactListId = contactListId;
            Item = item;
        }

        public long ContactListId { get; set; }

        public object Item { get; set; }
    }
}
