using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace CallFire_csharp_sdk.API.Soap
{
    public class BaseSoapClient<T>
        where T: IClient
    {
        private const string SoapEndpointAddress = "https://www.callfire.com/api/1.1/soap12"; 
        internal readonly IBroadcastServicePortTypeClient BroadcastService;
        internal readonly ISubscriptionServicePortTypeClient SubscriptionService;

        public BaseSoapClient(string username, string password)
        {
            if (typeof(T) == typeof(IBroadcastClient))
            {
                BroadcastService = CreateBroadcastSoapServiceClient(username, password);
            }
            if (typeof(T) == typeof(ISubscriptionClient))
            {
                SubscriptionService = CreateSubscriptionSoapServiceClient(username, password);
            }
        }

        private static BroadcastServicePortTypeClient CreateBroadcastSoapServiceClient(string username, string password)
        {
            var binding = CreateCustomBinding();
            var service = new BroadcastServicePortTypeClient(
                binding, new EndpointAddress(string.Format("{0}/broadcast", SoapEndpointAddress)))
                {
                    ClientCredentials = { UserName = { UserName = username, Password = password } }
                };
            return service;
        }

        private static SubscriptionServicePortTypeClient CreateSubscriptionSoapServiceClient(string username, string password)
        {
            var binding = CreateCustomBinding();
            var service = new SubscriptionServicePortTypeClient(
                binding, new EndpointAddress((string.Format("{0}/subscription", SoapEndpointAddress))))
            {
                ClientCredentials = { UserName = { UserName = username, Password = password } }
            };
            return service;
        }

        private static CustomBinding CreateCustomBinding()
        {
            var transportElement = new HttpsTransportBindingElement();
            transportElement.AuthenticationScheme = AuthenticationSchemes.Basic;

            var messegeElement = new TextMessageEncodingBindingElement
            {
                MessageVersion = MessageVersion.CreateVersion(EnvelopeVersion.Soap12, AddressingVersion.None)
            };
            var binding = new CustomBinding(messegeElement, transportElement);
            return binding;
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
