namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfContactListRequest
    {
        public CfContactListRequest(long contactListId, bool validate, CfContactSource contactSource)
        {
            ContactListId = contactListId;
            Validate = validate;
            ContactSource = contactSource;
        }

        public long ContactListId { get; set; }

        public bool Validate { get; set; }

        public CfContactSource ContactSource { get; set; }
    }
}
