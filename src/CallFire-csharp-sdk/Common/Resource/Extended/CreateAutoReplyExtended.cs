// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class CreateAutoReply
    {
        public CreateAutoReply(string requestId, AutoReply autoReply)
        {
            RequestId = requestId;
            AutoReply = autoReply;
        }

        public CreateAutoReply()
        {
        }
    }
}
