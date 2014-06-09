using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfGetRecordingData
    {
        public CfGetRecordingData(object[] items, CfItemsChoiceType[] itemsElementNameField, CfSoundFormat format)
        {
            Items = items;
            ItemsElementNameField = itemsElementNameField;
            Format = format;
        }

        public object[] Items { get; set; }

        /// <summary>
        /// List of items type [CallId, Name, RecordingId]
        /// </summary>
        public CfItemsChoiceType[] ItemsElementNameField { get; set; }

        /// <summary>
        /// Format of the returned recording [Wav, Mp3]
        /// </summary>
        public CfSoundFormat Format { get; set; }
    }
}
