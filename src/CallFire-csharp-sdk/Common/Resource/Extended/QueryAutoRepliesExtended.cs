using CallFire_csharp_sdk.Common.Resource;
// ReSharper disable once CheckNamespace - This is an extension from API.Soap


namespace CallFire_csharp_sdk.API.Soap
{
    public partial class QueryAutoReplies
    {
        public QueryAutoReplies(long maxResult, long firstResult, string number)
            : base(maxResult, firstResult)
        {
            Number = number;
        }

        public QueryAutoReplies(CfQueryAutoReplies source)
            : base(source.MaxResults, source.FirstResult)
        {
            Number = source.Number;
        }

        public QueryAutoReplies()
        {
        }
    }
}
