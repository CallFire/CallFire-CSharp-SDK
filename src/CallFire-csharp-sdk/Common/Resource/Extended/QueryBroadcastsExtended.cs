using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Resource.Mappers;

// ReSharper disable once CheckNamespace - This is an extension from API.Soap


namespace CallFire_csharp_sdk.API.Soap
{
    public partial class QueryBroadcasts
    {
        public QueryBroadcasts()
        {
        }
        
        public QueryBroadcasts(CfQueryBroadcasts source)
        {
            MaxResults = source.MaxResults;
            FirstResult = source.FirstResult;
            Type = EnumeratedMapper.ToSoapEnumerated(source.Type);
            if (source.Running.HasValue)
            {
                Running = source.Running.Value;
                RunningSpecified = true;
            }
            LabelName = source.LabelName;
        }
    }
}
