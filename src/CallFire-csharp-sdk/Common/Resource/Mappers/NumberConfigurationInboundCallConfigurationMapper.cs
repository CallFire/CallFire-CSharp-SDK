using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal static class NumberConfigurationInboundCallConfigurationMapper
    {
        internal static CfNumberConfigurationInboundCallConfiguration FromNumberConfigurationInboundCallConfiguration(
            NumberConfigurationInboundCallConfiguration source)
        {
            return source == null ? null : new CfNumberConfigurationInboundCallConfiguration(
                InboundConfigMapper.FromInboundConfig(source.Item));
        }

        internal static NumberConfigurationInboundCallConfiguration ToNumberConfigurationInboundCallConfiguration(
            CfNumberConfigurationInboundCallConfiguration source)
        {
            return source == null ? null : new NumberConfigurationInboundCallConfiguration(source);
        }
    }
}
