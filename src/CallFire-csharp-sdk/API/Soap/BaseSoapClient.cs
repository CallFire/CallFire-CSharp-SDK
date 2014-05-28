using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace CallFire_csharp_sdk.API.Soap
{
    public class BaseSoapClient
    {
        internal static CustomBinding GetCustomBinding()
        {
            var transportElement = new HttpsTransportBindingElement { AuthenticationScheme = AuthenticationSchemes.Basic };

            var messegeElement = new TextMessageEncodingBindingElement
            {
                MessageVersion = MessageVersion.CreateVersion(EnvelopeVersion.Soap12, AddressingVersion.None)
            };

            var binding = new CustomBinding(messegeElement, transportElement);
            return binding;
        }

        internal static EndpointAddress GetEndpointAddress<T>()
        {
            return new EndpointAddress(string.Format("{0}/{1}", BindingAdress.Soap, typeof(T).Name.ToLower()));
        }
    }
}
