namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfCreateNumberOrderBulkTollFree
    {
        public CfCreateNumberOrderBulkTollFree()
        {
        }

        public CfCreateNumberOrderBulkTollFree(int count)
        {
            Count = count;
        }

        /// <summary>
        /// Amount of phone numbers to aquire
        /// </summary>
        public int Count { get; set; }
    }
}
