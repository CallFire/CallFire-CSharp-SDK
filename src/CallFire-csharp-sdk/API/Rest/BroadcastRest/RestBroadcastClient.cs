using CallFire_csharp_sdk.Common.DataManagement;
using ServiceStack.ServiceClient.Web;

namespace CallFire_csharp_sdk.API.Rest.BroadcastRest
{
    public class RestBroadcastClient : BaseRestClient<CfBroadcast>, IBroadcastClient
    {
        public RestBroadcastClient(string username, string password)
            : base(username, password)
        {
        }

        internal RestBroadcastClient(JsonServiceClient jsonClient)
            : base(jsonClient)
        {
        }

        public long CreateBroadcast(CfBroadcast broadcast)
        {
            return Create(broadcast);
        }
    }
}
