using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal static class KeywordMapper
    {
        internal static CfKeyword FromKeyword(Keyword source)
        {
            if (source == null)
            {
                return null;
            }
            var state = EnumeratedMapper.EnumFromSoapEnumerated<CfNumberStatus>(source.Status.ToString());
            var leaseInfo = LeaseInfoMapper.FromLeaseInfo(source.LeaseInfo);
            return new CfKeyword(source.ShortCode, source.Keyword1, state, leaseInfo);
        }

        internal static Keyword ToKeyword(CfKeyword source)
        {
            return source == null ? null : new Keyword(source);
        }
    }
}
