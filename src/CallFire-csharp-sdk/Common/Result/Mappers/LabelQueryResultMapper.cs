using System.Linq;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.Resource.Mappers;

namespace CallFire_csharp_sdk.Common.Result.Mappers
{
    internal class LabelQueryResultMapper
    {
        internal static CfLabelQueryResult FromSoapLabelQueryResult(LabelQueryResult source)
        {
            return source == null
                ? null
                : new CfLabelQueryResult(source.TotalResults, source.Label.Select(LabelMapper.FromLabel).ToArray());
        }

        internal static LabelQueryResult ToSoapLabelQueryResult(CfLabelQueryResult source)
        {
            return source == null
                ? null
                : new LabelQueryResult
                {
                    TotalResults = source.TotalResults,
                    Label = source.Labels.Select(LabelMapper.ToLabel).ToArray()
                };
        }
    }
}
