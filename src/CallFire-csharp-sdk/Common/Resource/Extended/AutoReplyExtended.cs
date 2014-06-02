using CallFire_csharp_sdk.Common.DataManagement;
// ReSharper disable once CheckNamespace - This is an extension from API.Soap


namespace CallFire_csharp_sdk.API.Soap
{
    public partial class AutoReply
    {
        public AutoReply()
        {
        }
        
        public AutoReply(CfAutoReply source)
        {
            Number = source.Number;
            Keyword = source.Keyword;
            Match = source.Match;
            Message = source.Message;
            if (source.Id.HasValue)
            {
                id = source.Id.Value;
                idSpecified = true;
            }
        }
    }
}
