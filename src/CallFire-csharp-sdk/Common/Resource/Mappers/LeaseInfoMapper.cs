using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal static class LeaseInfoMapper
    {
        internal static CfLeaseInfo FromLeaseInfo(LeaseInfo source)
        {
            return source == null ? null : new CfLeaseInfo(source.LeaseBegin, source.LeaseEnd, source.AutoRenew);
        }

        internal static LeaseInfo ToLeaseInfo(CfLeaseInfo source)
        {
            return source == null ? null : new LeaseInfo(source);
        }
    }
}
