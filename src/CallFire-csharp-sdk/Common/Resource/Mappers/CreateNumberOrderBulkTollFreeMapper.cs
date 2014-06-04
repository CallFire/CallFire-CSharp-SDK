using CallFire_csharp_sdk.API.Soap;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal static class CreateNumberOrderBulkTollFreeMapper
    {
        internal static CfCreateNumberOrderBulkTollFree FromCreateNumberOrderBulkTollFree(
            CreateNumberOrderBulkTollFree source)
        {
            return source == null ? null : new CfCreateNumberOrderBulkTollFree(source.Count);
        }

        internal static CreateNumberOrderBulkTollFree ToCreateNumberOrderBulkTollFree(
            CfCreateNumberOrderBulkTollFree source)
        {
            return source == null ? null : new CreateNumberOrderBulkTollFree(source);
        }
    }
}
