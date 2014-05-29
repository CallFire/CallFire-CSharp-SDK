// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class SendRequest
    {
        protected SendRequest(string requestId, string type, string broadcastName, ToNumber[] toNumber, bool scrubBroadcastDuplicates)
        {
            RequestId = requestId;
            Type = type;
            BroadcastName = broadcastName;
            ToNumber = toNumber;
            ScrubBroadcastDuplicates = scrubBroadcastDuplicates;
        }
    }
}
