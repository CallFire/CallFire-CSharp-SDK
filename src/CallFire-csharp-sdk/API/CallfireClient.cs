using CallFire_csharp_sdk.API.Rest;
using CallFire_csharp_sdk.API.Soap;

namespace CallFire_csharp_sdk.API
{
    public class CallfireClient : ICallfireClient
    {
        private readonly string _username;
        private readonly string _password;
        private readonly CallfireClients _client;
        private IBroadcastClient _broadcastClient;
        private ISubscriptionClient _subscriptionClient;
        private ILabelClient _labelClient;

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

        public ISubscriptionClient Subscription
        {
            get
            {
                if (_subscriptionClient != null)
                {
                    return _subscriptionClient;
                }
                return _client == CallfireClients.Rest ?
                    (_subscriptionClient = new RestSubscriptionClient(_username, _password)) :
                    (_subscriptionClient = new SoapSubscriptionClient(_username, _password));
            }
        }

        public ILabelClient Label
        {
            get
            {
                if (_labelClient != null)
                {
                    return _labelClient;
                }
                return _client == CallfireClients.Rest ?
                    (_labelClient = new RestLabelClient(_username, _password)) :
                    (_labelClient = new SoapLabelClient(_username, _password));
            }
        }
    }
}
