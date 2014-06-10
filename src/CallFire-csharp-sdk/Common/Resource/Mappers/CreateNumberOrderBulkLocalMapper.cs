using CallFire_csharp_sdk.API.Soap;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal static class CreateNumberOrderBulkLocalMapper
    {
        internal static CfCreateNumberOrderBulkLocal FromCreateNumberOrderBulkLocal(CreateNumberOrderBulkLocal source)
        {
            if (source == null)
            {
                return null;
            }
            var region = RegionMapper.FromRegion(source.Region);
            return new CfCreateNumberOrderBulkLocal(source.Count, region);
        }

        internal static CreateNumberOrderBulkLocal ToCreateNumberOrderBulkLocal(CfCreateNumberOrderBulkLocal source)
        {
            return source == null ? null : new CreateNumberOrderBulkLocal(source);
        }
    }
}
