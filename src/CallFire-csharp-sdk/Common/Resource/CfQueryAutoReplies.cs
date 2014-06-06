namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfQueryAutoReplies : CfQuery
    {
        public CfQueryAutoReplies(long maxResult, long firstResult, string number)
            : base(maxResult, firstResult)
        {
            Number = number;
        }

        /// <summary>
        /// E.164 11 digit number
        /// </summary>
        public string Number { get; set; }
    }
}
