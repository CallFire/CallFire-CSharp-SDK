// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class SendCall
    {
        public SendCall(string requestId, string type, string broadcastName, ToNumber[] toNumber, bool scrubBroadcastDuplicates, BroadcastConfig item)
        {
            RequestId = requestId;
            Type = type;
            BroadcastName = broadcastName;
            ToNumber = toNumber;
            ScrubBroadcastDuplicates = scrubBroadcastDuplicates;
            Item = item;
        }

        public SendCall()
        {
        }
    }
}
