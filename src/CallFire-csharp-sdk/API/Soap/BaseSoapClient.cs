using System.ServiceModel;

namespace CallFire_csharp_sdk.API.Soap
{
    internal abstract class BaseSoapClient
    {
        private const string SoapEndpointAddress = "https://www.callfire.com/api/1.1/wsdl/callfire-service.wsdl";
        internal readonly IBroadcastServicePortTypeClient BroadcastService;

        internal BaseSoapClient(string username, string password)
            : this(CreateSoapServiceClient(username, password))
        {

        }

        private static BroadcastServicePortTypeClient CreateSoapServiceClient(string username, string password)
        {
            var service = new BroadcastServicePortTypeClient(
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
    }
}
