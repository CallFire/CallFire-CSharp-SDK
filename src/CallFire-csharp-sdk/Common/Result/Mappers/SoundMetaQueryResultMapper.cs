using System.Linq;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.Resource.Mappers;

namespace CallFire_csharp_sdk.Common.Result.Mappers
{
    internal static class SoundMetaQueryResultMapper
    {
        internal static CfSoundMetaQueryResult FromSoundMetaQueryResult(SoundMetaQueryResult source)
        {
            if (source == null)
            {
                return null;
            }

            var soundMeta = source.SoundMeta == null ? null
                            : source.SoundMeta.Select(SoundMetaMapper.FromSoundMeta).ToArray();
            return new CfSoundMetaQueryResult(source.TotalResults, soundMeta);
        }

        internal static SoundMetaQueryResult ToSoundMetaQueryResult(CfSoundMetaQueryResult source)
        {
            if (source == null)
            {
                return null;
            }

            var soundMeta = source.SoundMeta == null ? null
                            : source.SoundMeta.Select(SoundMetaMapper.ToSoundMeta).ToArray();
            return new SoundMetaQueryResult(source.TotalResults, soundMeta);
        }
    }
}
