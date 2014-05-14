using System.ServiceModel;

namespace CallFire_csharp_sdk.API.Soap
{
    internal abstract class BaseSoapClient
    {
        private const string SoapEndpointAddress = "https://www.callfire.com/api/1.1/wsdl/callfire-service.wsdl";
        internal readonly IBroadcastServicePortTypeClient BroadcastService;
        internal readonly ISubscriptionServicePortTypeClient SubscriptionService;

        internal BaseSoapClient(string username, string password, TypeInterface type)
        {
            switch (type)
            {
                case TypeInterface.Broadcast:
                {
                    BroadcastService = CreateBroadcastSoapServiceClient(username, password);
                    break;
                }
                case TypeInterface.Subscription:
                {
                    SubscriptionService = CreateSubscriptionSoapServiceClient(username, password);
                    break;
                }
            }
        }

        private static BroadcastServicePortTypeClient CreateBroadcastSoapServiceClient(string username, string password)
        {
            var service = new BroadcastServicePortTypeClient(
                new BasicHttpBinding(new BasicHttpSecurityMode()), new EndpointAddress(SoapEndpointAddress))
                {
                    ClientCredentials = { UserName = { UserName = username, Password = password } }
                };
            return service;
        }

        private static SubscriptionServicePortTypeClient CreateSubscriptionSoapServiceClient(string username, string password)
        {
            var service = new SubscriptionServicePortTypeClient(
                new BasicHttpBinding(new BasicHttpSecurityMode()), new EndpointAddress(SoapEndpointAddress))
            {
                ClientCredentials = { UserName = { UserName = username, Password = password } }
            };
            return service;
        }

        internal BaseSoapClient(IBroadcastServicePortTypeClient broadcastService)
        {
            BroadcastService = broadcastService;
        }

        internal BaseSoapClient(ISubscriptionServicePortTypeClient subscriptionService)
        {
            SubscriptionService = subscriptionService;
        }
    }
}
