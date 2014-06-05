using CallFire_csharp_sdk.Common.Resource;
// ReSharper disable once CheckNamespace - This is an extension from API.Soap


namespace CallFire_csharp_sdk.API.Soap
{
    public partial class RemoveContactsFromList
    {
        public RemoveContactsFromList()
        {
        }

        public RemoveContactsFromList(CfRemoveContactsFromList source)
        {
            ContactListId = source.ContactListId;
            Item = source.Item;
        }
    }
}
