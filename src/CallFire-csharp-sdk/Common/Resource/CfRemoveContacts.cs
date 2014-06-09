namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfRemoveContacts
    {
        public CfRemoveContacts(long[] contactId)
        {
            ContactId = contactId;
        }

        /// <summary>
        /// List of contact ids
        /// </summary>
        public long[] ContactId { get; set; }
    }
}
