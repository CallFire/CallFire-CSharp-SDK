using CallFire_csharp_sdk.Common.Resource;
// ReSharper disable once CheckNamespace - This is an extension from API.Soap


namespace CallFire_csharp_sdk.API.Soap
{
    public partial class GetContactHistory
    {
        public GetContactHistory()
        {
        }
        
        public GetContactHistory(CfGetContactHistory getContactHistory)
            : base(getContactHistory.MaxResults, getContactHistory.FirstResult)
        {
            ContactId = getContactHistory.ContactId;
        }
    }
}
