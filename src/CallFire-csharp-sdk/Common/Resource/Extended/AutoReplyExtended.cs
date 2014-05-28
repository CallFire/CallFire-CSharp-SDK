// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class AutoReply
    {
        public AutoReply(string number, string keyword, string match, string message, long identifier)
        {
            Number = number;
            Keyword = keyword;
            Match = match;
            Message = message;
            id = identifier;
        }

        public AutoReply()
        {
        }
    }
}
