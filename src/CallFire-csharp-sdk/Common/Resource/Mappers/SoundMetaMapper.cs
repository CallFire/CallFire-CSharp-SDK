using System.Linq;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal static class SoundMetaMapper
    {
        internal static CfSoundMeta[] FromSoundMeta(SoundMeta[] source)
        {
            return source == null ? null : source.Select(FromSoundMeta).ToArray();
        }

        internal static SoundMeta[] ToSoundMeta(CfSoundMeta[] source)
        {
            return source == null ? null : source.Select(ToSoundMeta).ToArray();
        }

        internal static CfSoundMeta FromSoundMeta(SoundMeta source)
        {
            return source == null ? null : new CfSoundMeta(EnumeratedMapper.EnumFromSoapEnumerated<CfSoundStatus>(source.Status.ToString()), 
                source.Name, source.Created, source.LengthInSeconds, source.id);
        }

        internal static SoundMeta ToSoundMeta(CfSoundMeta source)
        {
            return source == null ? null : new SoundMeta(EnumeratedMapper.ToSoapEnumerated<SoundStatus>(source.Status.ToString()),
                source.Name, source.Created, source.LengthInSeconds, source.Id);
        }
    }
}
