namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfGetContactHistory : CfQuery
    {
        public CfGetContactHistory()
        {
        }
        
        public CfGetContactHistory(long maxResult, long firstResult, long contactId)
            : base(maxResult, firstResult)
        {
            ContactId = contactId;
        }

        /// <summary>
        /// Contact to get history
        /// </summary>
        public long ContactId { get; set; }
    }
}
