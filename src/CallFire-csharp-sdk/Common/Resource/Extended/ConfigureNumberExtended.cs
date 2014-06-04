using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Resource.Mappers;
// ReSharper disable once CheckNamespace - This is an extension from API.Soap


namespace CallFire_csharp_sdk.API.Soap
{
    public partial class ConfigureNumber
    {
        public ConfigureNumber()
        {
        }

        public ConfigureNumber(CfConfigureNumber source)
        {
            Number = source.Number;
            NumberConfiguration = NumberConfigurationMapper.ToNumberConfiguration(source.NumberConfiguration);
        }
    }
}
