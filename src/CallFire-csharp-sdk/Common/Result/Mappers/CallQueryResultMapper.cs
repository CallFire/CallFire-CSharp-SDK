using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.Resource.Mappers;

namespace CallFire_csharp_sdk.Common.Result.Mappers
{
    internal static class CallQueryResultMapper
    {
        internal static CfCallQueryResult FromCallQueryResult(CallQueryResult source)
        {
            return source == null ? null : new CfCallQueryResult(source.TotalResults, CallMapper.FromCall(source.Call));
        }

        internal static CallQueryResult ToCallQueryResult(CfCallQueryResult source)
        {
            return source == null ? null : new CallQueryResult(source.TotalResults, CallMapper.ToCall(source.Calls));
        }
    }
}
