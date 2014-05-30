using System.Linq;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.Resource.Mappers;

namespace CallFire_csharp_sdk.Common.Result.Mappers
{
    internal class TextQueryResultMapper
    {
        internal static CfTextQueryResult FromSoapContactBatchQueryResult(TextQueryResult source)
        {
            if (source == null)
            {
                return null;
            }

            var text = source.Text == null ? null : source.Text.Select(TextMapper.FromText).ToArray();
            return new CfTextQueryResult(source.TotalResults, text);
        }

        internal static TextQueryResult ToSoapContactBatchQueryResult(CfTextQueryResult source)
        {
            if (source == null)
            {
                return null;
            }

            var text = source.Text == null ? null : source.Text.Select(TextMapper.ToText).ToArray();
            return new TextQueryResult(source.TotalResults, text);
        }
    }
}
