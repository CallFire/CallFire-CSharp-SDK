using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Resource.Mappers;
// ReSharper disable once CheckNamespace - This is an extension from API.Soap


namespace CallFire_csharp_sdk.API.Soap
{
    public partial class CreateAutoReply
    {
        public CreateAutoReply(CfCreateAutoReply cfCreateAutoReply)
        {
            RequestId = cfCreateAutoReply.RequestId;
            AutoReply = AutoReplyMapper.ToAutoReplay(cfCreateAutoReply.CfAutoReply);
        }

        public CreateAutoReply()
        {
        }
    }
}
