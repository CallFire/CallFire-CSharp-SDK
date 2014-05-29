using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Result
{
    public class CfAutoReplyQueryResult : CfQueryResult
    {
        public CfAutoReplyQueryResult(long totalResult, CfAutoReply[] cfAutoReply)
        {
            TotalResults = totalResult;
            CfAutoReply = cfAutoReply;
        }

        public CfAutoReply[] CfAutoReply { get; set; }
    }
}
