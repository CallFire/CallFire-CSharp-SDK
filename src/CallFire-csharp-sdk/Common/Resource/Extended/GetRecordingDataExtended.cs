// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class GetRecordingData
    {
        public GetRecordingData(object[] items, ItemsChoiceType[] itemsElementName, SoundFormat format)
        {
            Items = items;
            ItemsElementName = itemsElementName;
            Format = format;
        }
    }
}
