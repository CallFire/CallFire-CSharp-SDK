namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfCreateSoundRecordingCall
    {
        public CfCreateSoundRecordingCall(string toNumber)
        {
            ToNumber = toNumber;
        }

        public string ToNumber { get; set; }
    }
}
