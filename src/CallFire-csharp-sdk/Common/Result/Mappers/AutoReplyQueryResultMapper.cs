using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.Resource.Mappers;

namespace CallFire_csharp_sdk.Common.Result.Mappers
{
    internal static class AutoReplyQueryResultMapper
    {
        internal static CfAutoReplyQueryResult FromAutoReplyQueryResult(AutoReplyQueryResult source)
        {
            var autoReply = AutoReplyMapper.FromAutoReplay(source.AutoReply);
            return new CfAutoReplyQueryResult(source.TotalResults, autoReply);
        }

        internal static AutoReplyQueryResult ToAutoReplyQueryResult(CfAutoReplyQueryResult source)
        {
            var autoReply = AutoReplyMapper.ToAutoReplay(source.CfAutoReply);
            return new AutoReplyQueryResult(source.TotalResults, autoReply);
        }
    }
}
