using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Result
{
    public class CfSoundMetaQueryResult : CfQueryResult
    {
        public CfSoundMetaQueryResult(long totalResults, CfSoundMeta[] soundMeta)
            : base(totalResults)
        {
            SoundMeta = soundMeta;
        }

        /// <summary>
        /// List of SoundMeta
        /// </summary>
        public CfSoundMeta[] SoundMeta { get; set; }
    }
}
