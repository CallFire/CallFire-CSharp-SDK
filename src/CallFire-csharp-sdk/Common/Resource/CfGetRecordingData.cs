using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfGetRecordingData
    {
        public object[] Items { get; set; }

        public CfItemsChoiceType[] ItemsElementNameField { get; set; }

        public CfSoundFormat Format { get; set; }
    }
}
