using System.Linq;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.Resource.Mappers;

namespace CallFire_csharp_sdk.Common.Result.Mappers
{
    internal static class CallQueryResultMapper
    {
        internal static CfCallQueryResult FromCallQueryResult(CallQueryResult source)
        {
            if (source == null)
            {
                return null;
            }

            var call = source.Call == null ? null : source.Call.Select(CallMapper.FromCall).ToArray();
            return new CfCallQueryResult(source.TotalResults, call);
        }

        internal static CallQueryResult ToCallQueryResult(CfCallQueryResult source)
        {
            if (source == null)
            {
                return null;
            }

            var call = source.Calls == null ? null : source.Calls.Select(CallMapper.ToCall).ToArray();
            return new CallQueryResult(source.TotalResults, call);
        }
    }
}
