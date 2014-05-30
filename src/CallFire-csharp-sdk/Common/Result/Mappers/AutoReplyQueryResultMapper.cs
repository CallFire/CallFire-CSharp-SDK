using System.Linq;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.Resource.Mappers;

namespace CallFire_csharp_sdk.Common.Result.Mappers
{
    internal static class AutoReplyQueryResultMapper
    {
        internal static CfAutoReplyQueryResult FromAutoReplyQueryResult(AutoReplyQueryResult source)
        {
            if (source == null)
            {
                return null;
            }

            var autoReply = source.AutoReply == null ? null
                            : source.AutoReply.Select(AutoReplyMapper.FromAutoReplay).ToArray();

            return new CfAutoReplyQueryResult(source.TotalResults, autoReply);
        }

        internal static AutoReplyQueryResult ToAutoReplyQueryResult(CfAutoReplyQueryResult source)
        {
            if (source == null)
            {
                return null;
            }

            var autoReply = source.CfAutoReply == null ? null
                            : source.CfAutoReply.Select(AutoReplyMapper.ToAutoReplay).ToArray();
            return new AutoReplyQueryResult(source.TotalResults, autoReply);
        }
    }
}
