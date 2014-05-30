namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfCreateContactList : CfRequest
    {
        public CfCreateContactList(string requestId, string name, bool validate, CfContactSource contactSource)
        {
            RequestId = requestId;
            Name = name;
            Validate = validate;
            ContactSource = contactSource;
        }

        public string Name { get; set; }

        public bool Validate { get; set; }

        public CfContactSource ContactSource { get; set; }
    }
}
