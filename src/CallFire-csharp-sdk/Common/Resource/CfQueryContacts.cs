namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfQueryContacts : CfQuery
    {
        public CfQueryContacts()
        {
        }

        public CfQueryContacts(long maxResult, long firstResult, string field, long? contactListId, string str)
            : base(maxResult, firstResult)
        {
            Field = field;
            ContactListId = contactListId;
            String = str;
        }

        /// <summary>
        /// Field to filter by
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// ContactList to filter by
        /// </summary>
        public long? ContactListId { get; set; }

        /// <summary>
        /// Substring contained in Contact to filter by
        /// </summary>
        public string String { get; set; }  
    }
}
