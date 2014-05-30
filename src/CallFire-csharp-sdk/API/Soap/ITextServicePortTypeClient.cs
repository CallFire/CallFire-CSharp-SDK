namespace CallFire_csharp_sdk.API.Soap
{
    public interface ITextServicePortTypeClient : IServicePortClient
    {
        long SendText(SendText sendText1);
        TextQueryResult QueryTexts(ActionQuery queryText1);
        Text GetText(IdRequest getText1);
        long CreateAutoReply(CreateAutoReply createAutoReply1);
        AutoReplyQueryResult QueryAutoReplies(QueryAutoReplies queryAutoReplies1);
        AutoReply GetAutoReply(IdRequest getAutoReply1);
        void DeleteAutoReply(IdRequest deleteAutoReply1);
    }
}
