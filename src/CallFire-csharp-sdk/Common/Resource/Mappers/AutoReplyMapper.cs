using System.Linq;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal static class AutoReplyMapper
    {
        internal static CfAutoReply[] FromAutoReplay(AutoReply[] source)
        {
            return source == null ? null : source.Select(FromAutoReplay).ToArray();
        }

        internal static AutoReply[] ToAutoReplay(CfAutoReply[] source)
        {
            return source == null ? null : source.Select(ToAutoReplay).ToArray();
        }
        
        internal static CfAutoReply FromAutoReplay(AutoReply source)
        {
            return source == null ? null : new CfAutoReply(source.Number, source.Keyword, source.Match, source.Message, source.id);
        }

        internal static AutoReply ToAutoReplay(CfAutoReply source)
        {
            return source == null ? null : new AutoReply(source.Number, source.Keyword, source.Match, source.Message, source.Id);
        }
    }
}
