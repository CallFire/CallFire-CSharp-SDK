using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource.Mappers;

// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class NumberConfigurationInboundCallConfiguration
    {
        public NumberConfigurationInboundCallConfiguration()
        {
        }

        public NumberConfigurationInboundCallConfiguration(CfNumberConfigurationInboundCallConfiguration source)
        {
            Item = InboundConfigMapper.ToInboundConfig(source.Item);
        }
    }
}
