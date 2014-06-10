using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal static class NumberMapper
    {
        internal static CfNumber FromNumber(Number source)
        {
            if (source == null)
            {
                return null;
            }
            var region = RegionMapper.FromRegion(source.Region);
            var status = EnumeratedMapper.EnumFromSoapEnumerated<CfNumberStatus>(source.Status.ToString());
            var leaseInfo = LeaseInfoMapper.FromLeaseInfo(source.LeaseInfo);
            var numberConfiguration = NumberConfigurationMapper.FromNumberConfiguration(source.NumberConfiguration);
            return new CfNumber(source.Number1, source.NationalFormat, source.TollFree, region, status, leaseInfo, numberConfiguration);
        }

        internal static Number ToNumber(CfNumber source)
        {
            return source == null ? null : new Number(source);
        }
    }
}
