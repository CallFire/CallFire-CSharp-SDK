using System.Linq;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.Resource.Mappers;

namespace CallFire_csharp_sdk.Common.Result.Mappers
{
    internal static class SoundMetaQueryResultMapper
    {
        internal static CfSoundMetaQueryResult FromSoundMetaQueryResult(SoundMetaQueryResult source)
        {
            return source == null ? null : new CfSoundMetaQueryResult(
                source.TotalResults,
                source.SoundMeta == null ? null : source.SoundMeta.Select(SoundMetaMapper.FromSoundMeta).ToArray());
        }

        internal static SoundMetaQueryResult ToSoundMetaQueryResult(CfSoundMetaQueryResult source)
        {
            return source == null ? null : new SoundMetaQueryResult(
                source.TotalResults,
                source.SoundMeta == null ? null : source.SoundMeta.Select(SoundMetaMapper.ToSoundMeta).ToArray());
        }
    }
}
