namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfGetContactHistory : CfQuery
    {
        public CfGetContactHistory(long maxResult, long firstResult, long contactId)
            : base(maxResult, firstResult)
        {
            ContactId = contactId;
        }

        public long ContactId { get; set; }
    }
}
