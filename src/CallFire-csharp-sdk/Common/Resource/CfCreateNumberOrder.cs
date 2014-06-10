namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfCreateNumberOrder
    {
        public CfCreateNumberOrder()
        {
        }

        public CfCreateNumberOrder(string numbers, string keywords, CfCreateNumberOrderBulkLocal bulkLocal, 
            CfCreateNumberOrderBulkTollFree bulkTollFree)
        {
            Numbers = numbers;
            Keywords = keywords;
            BulkLocal = bulkLocal;
            BulkTollFree = bulkTollFree;
        }

        /// <summary>
        /// List E.164 11 digit numbers space separated
        /// </summary>
        public string Numbers { get; set; }

        /// <summary>
        /// List of keywords space separated
        /// </summary>
        public string Keywords { get; set; }

        /// <summary>
        /// Local numbers to aquire
        /// </summary>
        public CfCreateNumberOrderBulkLocal BulkLocal { get; set; }

        /// <summary>
        /// Toll free numbers to aquire
        /// </summary>
        public CfCreateNumberOrderBulkTollFree BulkTollFree { get; set; }
    }
}
