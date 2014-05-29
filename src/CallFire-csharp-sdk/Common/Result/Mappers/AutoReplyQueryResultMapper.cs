using System.Linq;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.Resource.Mappers;

namespace CallFire_csharp_sdk.Common.Result.Mappers
{
    internal static class AutoReplyQueryResultMapper
    {
        internal static CfAutoReplyQueryResult FromAutoReplyQueryResult(AutoReplyQueryResult source)
        {
            return source == null ? null : new CfAutoReplyQueryResult(
                source.TotalResults,
                source.AutoReply == null ? null : source.AutoReply.Select(AutoReplyMapper.FromAutoReplay).ToArray());
        }

        internal static AutoReplyQueryResult ToAutoReplyQueryResult(CfAutoReplyQueryResult source)
        {
            return source == null ? null : new AutoReplyQueryResult(
                source.TotalResults,
                source.CfAutoReply == null ? null : source.CfAutoReply.Select(AutoReplyMapper.ToAutoReplay).ToArray());
        }
    }
}
