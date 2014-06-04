using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource.Mappers;

// ReSharper disable once CheckNamespace - This is an extension from API.Soap


namespace CallFire_csharp_sdk.API.Soap
{
    public partial class NumberConfiguration
    {
        public NumberConfiguration()
        {
        }

        public NumberConfiguration(CfNumberConfiguration source)
        {
            if (source.CallFeature.HasValue)
            {
                CallFeature = EnumeratedMapper.ToSoapEnumerated<NumberFeature>(source.CallFeature.Value.ToString());
                CallFeatureSpecified = true;
            }
            if (source.TextFeature.HasValue)
            {
                TextFeature = EnumeratedMapper.ToSoapEnumerated<NumberFeature>(source.TextFeature.Value.ToString());
                TextFeatureSpecified = true;
            }
            if (source.InboundCallConfigurationType.HasValue)
            {
                InboundCallConfigurationType =
                    EnumeratedMapper.ToSoapEnumerated<InboundType>(source.InboundCallConfigurationType.Value.ToString());
                InboundCallConfigurationTypeSpecified = true;
            }
            InboundCallConfiguration = NumberConfigurationInboundCallConfigurationMapper
                .ToNumberConfigurationInboundCallConfiguration(source.InboundCallConfiguration);
        }
    }
}
