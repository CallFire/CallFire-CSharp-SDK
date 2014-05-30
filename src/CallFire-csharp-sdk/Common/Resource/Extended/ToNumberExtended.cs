using System.Xml;
// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class ToNumber
    {
        public ToNumber()
        {
        }
        
        public ToNumber(string clientData, XmlAttribute[] anyAttr, string value)
        {
            ClientData = clientData;
            AnyAttr = anyAttr;
            Value = value;
        }
    }
}
