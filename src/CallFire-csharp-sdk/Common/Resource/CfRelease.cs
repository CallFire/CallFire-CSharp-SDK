namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfRelease
    {
        public CfRelease()
        {
        }

        public CfRelease(string number, string keyword)
        {
            Number = number;
            Keyword = keyword;
        }

        public string Number { get; set; }

        public string Keyword { get; set; }
    }
}
