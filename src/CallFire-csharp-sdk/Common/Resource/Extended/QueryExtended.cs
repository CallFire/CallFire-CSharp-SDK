// ReSharper disable once CheckNamespace - This is an extension from API.Soap

namespace CallFire_csharp_sdk.API.Soap
{
    public partial class Query
    {
        public Query(long maxResult, long firstResult)
        {
            MaxResults = maxResult;
            FirstResult = firstResult;
        }
    }
}
