using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource.Mappers;

// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class Number
    {
        public Number()
        {
        }

        public Number(CfNumber source)
        {
            Number1 = source.Number1;
            NationalFormat = source.NationalFormat;
            TollFree = source.TollFree;
            Region = RegionMapper.ToRegion(source.Region);
            if (source.Status.HasValue)
            {
                Status = EnumeratedMapper.ToSoapEnumerated<NumberStatus>(source.Status.Value.ToString());
                StatusSpecified = true;
            }
            LeaseInfo = LeaseInfoMapper.ToLeaseInfo(source.LeaseInfo);
            NumberConfiguration = NumberConfigurationMapper.ToNumberConfiguration(source.NumberConfiguration);
        }
    }
}
