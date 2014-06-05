namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfRemoveContacts
    {
        public CfRemoveContacts(long[] contactId)
        {
            ContactId = contactId;
        }

        public long[] ContactId { get; set; }
    }
}
