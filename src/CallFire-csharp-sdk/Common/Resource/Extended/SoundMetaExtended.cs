using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource.Mappers;

// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class SoundMeta
    {
        public SoundMeta()
        {
        }
        
        public SoundMeta(CfSoundMeta source)
        {
            Status = EnumeratedMapper.ToSoapEnumerated<SoundStatus>(source.Status.ToString());
            Name = source.Name;
            Created = source.Created;
            if (source.LengthInSeconds.HasValue)
            {
                LengthInSeconds = source.LengthInSeconds.Value;
                lengthInSecondsFieldSpecified = true;
            }
            id = source.Id;
        }
    }
}
