using System.Linq;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.Resource.Mappers;

namespace CallFire_csharp_sdk.Common.Result.Mappers
{
    internal static class NumberQueryResultMapper
    {
        internal static CfNumberQueryResult FromNumberQueryResult(NumberQueryResult source)
        {
            if (source == null)
            {
                return null;
            }
            var number = source.Number == null ? null : source.Number.Select(NumberMapper.FromNumber).ToArray();
            return new CfNumberQueryResult(source.TotalResults, number);
        }

        internal static NumberQueryResult ToNumberQueryResult(CfNumberQueryResult source)
        {
            if (source == null)
            {
                return null;
            }
            var number = source.Number == null ? null : source.Number.Select(NumberMapper.ToNumber).ToArray();
            return new NumberQueryResult(source.TotalResults, number);
        }
    }
}
