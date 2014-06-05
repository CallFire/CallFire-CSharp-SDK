namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfContactSourceNumbers
    {
        public CfContactSourceNumbers(string fieldName, string[] text)
        {
            FieldName = fieldName;
            Text = text;
        }

        public string FieldName { get; set; }

        public string[] Text { get; set; }
    }
}
