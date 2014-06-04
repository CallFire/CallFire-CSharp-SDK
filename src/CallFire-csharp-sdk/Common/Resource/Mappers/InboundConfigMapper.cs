using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal static class InboundConfigMapper
    {
        internal static CfInboundConfig FromInboundConfig(InboundConfig source)
        {
            CfInboundConfig item = null;
            if (source.GetType() == typeof(IvrInboundConfig))
            {
                item = IvrInboundConfigMapper.FromIvrInboundConfig((IvrInboundConfig)source);
            }
            else if (source.GetType() == typeof(CallTrackingConfig))
            {
                item = CallTrackingConfigMapper.FromCallTrackingConfig((CallTrackingConfig)source);
            }
            return item;
        }

        internal static InboundConfig ToInboundConfig(CfInboundConfig source)
        {
            InboundConfig item = null;
            if (source.GetType() == typeof(CfIvrInboundConfig))
            {
                item = IvrInboundConfigMapper.ToIvrInboundConfig((CfIvrInboundConfig)source);
            }
            else if (source.GetType() == typeof(CfCallTrackingConfig))
            {
                item = CallTrackingConfigMapper.ToCallTrackingConfig((CfCallTrackingConfig)source);
            }
            return item;
        }
    }
}
