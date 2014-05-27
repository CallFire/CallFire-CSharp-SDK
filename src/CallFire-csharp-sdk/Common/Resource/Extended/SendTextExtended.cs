// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class SendText
    {
        public SendText(string requestId, string type, string broadcastName, ToNumber[] toNumber, bool scrubBroadcastDuplicates, 
            TextBroadcastConfig textBroadcastConfig, long broadcastId, bool useDefaultBroadcast) 
            : base(requestId, type, broadcastName, toNumber, scrubBroadcastDuplicates)
        {
            TextBroadcastConfig = textBroadcastConfig;
            BroadcastId = broadcastId;
            UseDefaultBroadcast = useDefaultBroadcast;
        }
    }
}
