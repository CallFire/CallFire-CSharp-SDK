using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfCreateAutoReply : CfRequest
    {
        public CfCreateAutoReply(string requestId, CfAutoReply cfAutoReply)
        {
            RequestId = requestId;
            CfAutoReply = cfAutoReply;
        }

        public CfAutoReply CfAutoReply { get; set; }
    }
}
