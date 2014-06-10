using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Resource.Mappers;

// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class CreateNumberOrderBulkLocal
    {
        public CreateNumberOrderBulkLocal()
        {
        }

        public CreateNumberOrderBulkLocal(CfCreateNumberOrderBulkLocal source)
        {
            Count = source.Count;
            Region = RegionMapper.ToRegion(source.Region);
        }
    }
}
