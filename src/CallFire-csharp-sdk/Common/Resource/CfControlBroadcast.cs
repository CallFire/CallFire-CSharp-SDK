namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfControlBroadcast : CfUniqueResource
    {
        public CfControlBroadcast(long id, string requestId, CfBroadcastCommand? command, int? maxActive)
            : base(id)
        {
            RequestId = requestId;
            Command = command;
            MaxActive = maxActive;
        }

        public string RequestId { get; set; }

        public CfBroadcastCommand? Command { get; set; }

        /// <summary>
        /// Max simultaneous calls
        /// </summary>
        public int? MaxActive { get; set; }
    }
}
