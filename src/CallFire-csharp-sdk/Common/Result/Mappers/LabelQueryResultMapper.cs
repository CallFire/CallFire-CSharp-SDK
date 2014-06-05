using System.Linq;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.Resource.Mappers;

namespace CallFire_csharp_sdk.Common.Result.Mappers
{
    internal class LabelQueryResultMapper
    {
        internal static CfLabelQueryResult FromSoapLabelQueryResult(LabelQueryResult source)
        {
            if (source == null)
            {
                return null;
            }

            var label = source.Label == null ? null : source.Label.Select(LabelMapper.FromLabel).ToArray();
            return new CfLabelQueryResult(source.TotalResults, label);
        }

        internal static LabelQueryResult ToSoapLabelQueryResult(CfLabelQueryResult source)
        {
            if (source == null)
            {
                return null;
            }

            var label = source.Labels == null ? null : source.Labels.Select(LabelMapper.ToLabel).ToArray();
            return new LabelQueryResult(source.TotalResults, label);
        }
    }
}
