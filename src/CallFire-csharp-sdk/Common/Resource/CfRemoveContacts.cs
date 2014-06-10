namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfRemoveContacts
    {
        public CfRemoveContacts(long[] contactId)
        {
            ContactId = contactId;
        }

        /// <summary>
        /// List of contact IDs
        /// </summary>
        public long[] ContactId { get; set; }
    }
}
