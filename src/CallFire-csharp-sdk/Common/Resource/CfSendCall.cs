using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfSendCall : CfSendRequest
    {
        public CfBroadcastConfig Item { get; set; }
    }
}
