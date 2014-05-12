// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class ControlBroadcast
    {
        public ControlBroadcast(long id, string requestId, BroadcastCommand command, int maxActive) : base(id)
        {
            RequestId = requestId;
            Command = command;
            MaxActive = maxActive;
        }
    }
}
