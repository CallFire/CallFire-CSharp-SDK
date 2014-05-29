using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Resource.Mappers;

// ReSharper disable once CheckNamespace - This is an extension from API.Soap


namespace CallFire_csharp_sdk.API.Soap
{
    public partial class GetSoundData
    {
        public GetSoundData(CfGetSoundData cfGetSoundData)
            : base(cfGetSoundData.Id)
        {
            Format = EnumeratedMapper.ToSoapEnumerated<SoundFormat>(cfGetSoundData.Format.ToString());
        }
    }
}
