using CallFire_csharp_sdk.Common.DataManagement;
// ReSharper disable once CheckNamespace - This is an extension from API.Soap


namespace CallFire_csharp_sdk.API.Soap
{
    public partial class IvrInboundConfig
    {
        public IvrInboundConfig()
        {
        }

        public IvrInboundConfig(CfIvrInboundConfig source)
        {
            if (source.Id.HasValue)
            {
                id = source.Id.Value;
                idSpecified = true;
            }
            DialplanXml = source.DialplanXml;
        }
    }
}
