// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class SoundMetaQueryResult
    {
        public SoundMetaQueryResult(long totalResults, SoundMeta[] soundMeta)
        {
            TotalResults = totalResults;
            SoundMeta = soundMeta;
        }

        public SoundMetaQueryResult()
        {
        }
    }
}
