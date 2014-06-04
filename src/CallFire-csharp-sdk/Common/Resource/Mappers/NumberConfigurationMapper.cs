using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal static class NumberConfigurationMapper
    {
        internal static CfNumberConfiguration FromNumberConfiguration(NumberConfiguration source)
        {
            if (source == null)
            {
                return null;
            }
            var callFeature = EnumeratedMapper.EnumFromSoapEnumerated<CfNumberFeature>(source.CallFeature.ToString());
            var textFeature = EnumeratedMapper.EnumFromSoapEnumerated<CfNumberFeature>(source.TextFeature.ToString());
            var inboundCallConfigurationType = EnumeratedMapper.EnumFromSoapEnumerated<CfInboundType>(source.InboundCallConfigurationType.ToString());
            var inboundCallConfiguration = NumberConfigurationInboundCallConfigurationMapper.FromNumberConfigurationInboundCallConfiguration(source.InboundCallConfiguration);
            return new CfNumberConfiguration(callFeature, textFeature, inboundCallConfigurationType, inboundCallConfiguration);
        }

        internal static NumberConfiguration ToNumberConfiguration(CfNumberConfiguration source)
        {
            return source == null ? null : new NumberConfiguration(source);
        }
    }
}
