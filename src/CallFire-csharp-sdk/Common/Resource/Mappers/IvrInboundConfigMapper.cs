using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal static class IvrInboundConfigMapper
    {
        internal static CfIvrInboundConfig FromIvrInboundConfig(IvrInboundConfig source)
        {
            return source == null ? null : new CfIvrInboundConfig(source.id, source.DialplanXml);
        }

        internal static IvrInboundConfig ToIvrInboundConfig(CfIvrInboundConfig source)
        {
            return source == null ? null : new IvrInboundConfig(source);
        }
    }
}
