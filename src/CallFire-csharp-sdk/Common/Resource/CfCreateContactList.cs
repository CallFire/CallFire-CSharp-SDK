namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfCreateContactList : CfRequest
    {
        public CfCreateContactList()
        {
            Validate = true;
        }

        public CfCreateContactList(string requestId, string name, bool validate, CfContactSource contactSource)
        {
            RequestId = requestId;
            Name = name;
            Validate = validate;
            ContactSource = contactSource;
        }

        /// <summary>
        /// Name of contact list
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Turn off list validation (default: true)
        /// </summary>
        public bool Validate { get; set; }

        /// <summary>
        /// List of contacts, numbers, contactIds, or csv file
        /// </summary>
        public CfContactSource ContactSource { get; set; }
    }
}
