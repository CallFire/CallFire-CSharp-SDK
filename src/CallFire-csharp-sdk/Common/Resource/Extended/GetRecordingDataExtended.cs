using System;
using System.Linq;
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
            var stringArray = cfGetRecordingData.ItemsElementNameField == null ? null : cfGetRecordingData.ItemsElementNameField.ToList().ConvertAll(i => i.ToString()).ToArray();
            ItemsElementName = stringArray == null ? null : stringArray.Select(s => (ItemsChoiceType)Enum.Parse(typeof(ItemsChoiceType), s)).ToArray();
            Format = EnumeratedMapper.ToSoapEnumerated<SoundFormat>(cfGetRecordingData.Format.ToString());
        }
    }
}
