namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfRemoveContactsFromList
    {
        public CfRemoveContactsFromList(long contactListId, long[] contactId, string[] numbers)
        {
            ContactListId = contactListId;
            ContactId = contactId;
            Numbers = numbers;
        }

        public long ContactListId { get; set; }

        public long[] ContactId { get; set; }

        public string[] Numbers { get; set; }
    }
}
