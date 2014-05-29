using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Resource.Mappers;
// ReSharper disable once CheckNamespace - This is an extension from API.Soap


namespace CallFire_csharp_sdk.API.Soap
{
    public partial class GetRecordingData
    {
        public GetRecordingData(CfGetRecordingData cfGetRecordingData)
        {
            Items = cfGetRecordingData.Items;
            ItemsElementName = EnumeratedMapper.ToArraySoapEnumerated<CfItemsChoiceType, ItemsChoiceType>(cfGetRecordingData.ItemsElementNameField);
            Format = EnumeratedMapper.ToSoapEnumerated<SoundFormat>(cfGetRecordingData.Format.ToString());
        }
    }
}
