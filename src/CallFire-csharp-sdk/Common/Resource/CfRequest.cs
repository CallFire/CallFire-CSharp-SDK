namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfRequest
    {
        /// <summary>
        /// Unique ID, used to dedupe requests and make sure request is not processed twice
        /// </summary>
        public string RequestId { get; set; }
    }
}
