namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfContactListRequest
    {
        public CfContactListRequest()
        {
        }

        public CfContactListRequest(long contactListId, bool validate, CfContactSource contactSource)
        {
            ContactListId = contactListId;
            Validate = validate;
            ContactSource = contactSource;
        }

        /// <summary>
        /// Unique ID of ContactList
        /// </summary>
        public long ContactListId { get; set; }

        /// <summary>
        /// Turn off list validation
        /// </summary>
        public bool Validate { get; set; }

        /// <summary>
        /// List of contacts, numbers, contactIds, or csv file
        /// </summary>
        public CfContactSource ContactSource { get; set; }
    }
}
