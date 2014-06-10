using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Resource.Mappers;

// ReSharper disable once CheckNamespace - This is an extension from API.Soap


namespace CallFire_csharp_sdk.API.Soap
{
    public partial class QueryNumbers
    {
        public QueryNumbers()
        {
        }

        public QueryNumbers(CfQueryNumbers source)
        {
            MaxResults = source.MaxResults;
            FirstResult = source.FirstResult;
            Region = RegionMapper.ToRegion(source.Region);
            LabelName = source.LabelName;
        }
    }
}
