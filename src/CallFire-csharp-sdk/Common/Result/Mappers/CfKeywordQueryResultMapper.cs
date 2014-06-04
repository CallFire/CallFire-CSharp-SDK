using System.Linq;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.Resource.Mappers;

namespace CallFire_csharp_sdk.Common.Result.Mappers
{
    internal static class CfKeywordQueryResultMapper
    {
        internal static CfKeywordQueryResult FromKeywordQueryResult(KeywordQueryResult source)
        {
            if (source == null)
            {
                return null;
            }

            var keyword = source.Keyword == null ? null : source.Keyword.Select(KeywordMapper.FromKeyword).ToArray();
            return new CfKeywordQueryResult(source.TotalResults, keyword);
        }

        internal static KeywordQueryResult ToKeywordQueryResult(CfKeywordQueryResult source)
        {
            if (source == null)
            {
                return null;
            }
            var keyword = source.Keyword == null ? null : source.Keyword.Select(KeywordMapper.ToKeyword).ToArray();
            return new KeywordQueryResult(source.TotalResults, keyword);
        }
    }
}
