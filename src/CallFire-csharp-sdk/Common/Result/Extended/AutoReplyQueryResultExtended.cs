// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class AutoReplyQueryResult
    {
        public AutoReplyQueryResult(long totalResult, AutoReply[] cfAutoReply)
        {
            TotalResults = totalResult;
            AutoReply = cfAutoReply;
        }

        public AutoReplyQueryResult()
        {
        }
    }
}
