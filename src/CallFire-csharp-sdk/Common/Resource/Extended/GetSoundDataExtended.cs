// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class GetSoundData
    {
        public GetSoundData(long id, SoundFormat format)
            : base(id)
        {
            Format = format;
        }
    }
}
