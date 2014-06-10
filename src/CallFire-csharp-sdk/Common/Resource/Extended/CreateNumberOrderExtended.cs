using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Resource.Mappers;

// ReSharper disable once CheckNamespace - This is an extension from API.Soap


namespace CallFire_csharp_sdk.API.Soap
{
    public partial class CreateNumberOrder
    {
        public CreateNumberOrder()
        {
        }

        public CreateNumberOrder(CfCreateNumberOrder source)
        {
            Numbers = source.Numbers;
            Keywords = source.Keywords;
            BulkLocal = CreateNumberOrderBulkLocalMapper.ToCreateNumberOrderBulkLocal(source.BulkLocal);
            BulkTollFree = CreateNumberOrderBulkTollFreeMapper.ToCreateNumberOrderBulkTollFree(source.BulkTollFree);
        }
    }
}
