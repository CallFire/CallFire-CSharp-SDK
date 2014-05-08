using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.API.Soap
{
    internal class SoapBroadcastClient : BaseSoapClient, IBroadcastClient
    {
        internal SoapBroadcastClient(string username, string password)
            : base(username, password)
        {
        }

        internal SoapBroadcastClient(IBroadcastServicePortTypeClient client) : base(client)
        {
        }

        public long CreateBroadcast(CfBroadcast broadcast)
        {
            return BroadcastService.CreateBroadcast(new BroadcastRequest());
        }
    }
}
