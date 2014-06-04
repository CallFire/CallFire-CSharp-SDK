namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfCreateNumberOrder
    {
        public CfCreateNumberOrder(string numbers, string keywords, CfCreateNumberOrderBulkLocal bulkLocal, 
            CfCreateNumberOrderBulkTollFree bulkTollFree)
        {
            Numbers = numbers;
            Keywords = keywords;
            BulkLocal = bulkLocal;
            BulkTollFree = bulkTollFree;
        }

        public string Numbers { get; set; }

        public string Keywords { get; set; }

        public CfCreateNumberOrderBulkLocal BulkLocal { get; set; }

        public CfCreateNumberOrderBulkTollFree BulkTollFree { get; set; }
    }
}
