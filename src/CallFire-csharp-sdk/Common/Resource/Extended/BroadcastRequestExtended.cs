// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class BroadcastRequest
    {
        public BroadcastRequest()
        {
        }
        
        public BroadcastRequest(string requestId, Broadcast broadcast)
        {
            RequestId = requestId;
            Broadcast = broadcast;
        }
    }
}
