using System.Linq;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.Resource.Mappers;

namespace CallFire_csharp_sdk.Common.Result.Mappers
{
    internal static class CallQueryResultMapper
    {
        internal static CfCallQueryResult FromCallQueryResult(CallQueryResult source)
        {
            return source == null ? null : new CfCallQueryResult(
                source.TotalResults,
                source.Call == null ? null : source.Call.Select(CallMapper.FromCall).ToArray());
        }

        internal static CallQueryResult ToCallQueryResult(CfCallQueryResult source)
        {
            return source == null ? null : new CallQueryResult(
                source.TotalResults,
                source.Calls == null ? null : source.Calls.Select(CallMapper.ToCall).ToArray());
        }
    }
}
