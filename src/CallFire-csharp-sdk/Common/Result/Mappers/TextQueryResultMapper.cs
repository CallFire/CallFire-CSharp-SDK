using System.Linq;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.Resource.Mappers;

namespace CallFire_csharp_sdk.Common.Result.Mappers
{
    internal class TextQueryResultMapper
    {
        internal static CfTextQueryResult FromSoapContactBatchQueryResult(TextQueryResult source)
        {
            return source == null ? null :
                new CfTextQueryResult(source.TotalResults,
                    source.Text == null ? null : source.Text.Select(TextMapper.FromText).ToArray());
        }

        internal static TextQueryResult ToSoapContactBatchQueryResult(CfTextQueryResult source)
        {
            return source == null ? null :
                new TextQueryResult(source.TotalResults,
                    source.Text == null ? null : source.Text.Select(TextMapper.ToText).ToArray());
        }
    }
}
