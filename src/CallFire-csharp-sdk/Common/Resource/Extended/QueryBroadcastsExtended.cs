using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Resource.Mappers;

// ReSharper disable once CheckNamespace - This is an extension from API.Soap


namespace CallFire_csharp_sdk.API.Soap
{
    public partial class QueryBroadcasts
    {
        public QueryBroadcasts(CfQueryBroadcasts source)
        {
            MaxResults = source.MaxResults;
            FirstResult = source.FirstResult;
            Type = EnumeratedMapper.ToSoapEnumerated(source.Type);
            Running = source.Running.HasValue && source.Running.Value;
            LabelName = source.LabelName;
        }

        public QueryBroadcasts()
        {
        }
    }
}
