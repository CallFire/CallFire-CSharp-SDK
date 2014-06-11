namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfControlBroadcast : CfUniqueResource
    {
        public CfControlBroadcast()
        {
        }

        public CfControlBroadcast(long id, string requestId, CfBroadcastCommand? command, int? maxActive)
            : base(id)
        {
            RequestId = requestId;
            Command = command;
            MaxActive = maxActive;
        }

        public string RequestId { get; set; }

        /// <summary>
        /// Command [Start, Stop, Archive]
        /// </summary>
        public CfBroadcastCommand? Command { get; set; }

        /// <summary>
        /// Max simultaneous calls
        /// </summary>
        public int? MaxActive { get; set; }
    }
}
