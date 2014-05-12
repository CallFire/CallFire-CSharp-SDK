using CallFire_csharp_sdk.API.Rest.BroadcastRest;
using CallFire_csharp_sdk.API.Soap;

namespace CallFire_csharp_sdk.API
{
    public class CallfireClient : ICallfireClient
    {
        private readonly string _username;
        private readonly string _password;
        private readonly CallfireClients _client;
        private IBroadcastClient _broadcastClient;

        public CallfireClient(string username, string password, CallfireClients client)
        {
            _username = username;
            _password = password;
            _client = client;
        }

        public IBroadcastClient Broadcasts
        {
            get
            {
                if (_broadcastClient != null)
                {
                    return _broadcastClient;
                }
                return _client == CallfireClients.Rest ?
                    (_broadcastClient = new RestBroadcastClient(_username, _password)) :
                    (_broadcastClient = new SoapBroadcastClient(_username, _password));
            }
        }
    }
}
