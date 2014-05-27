namespace CallFire_csharp_sdk.API.Soap
{
    public interface ITextServicePortTypeClient
    {
        long SendText(SendText sendText1);
        TextQueryResult QueryTexts(ActionQuery queryText1);
        Text GetText(IdRequest getText1);
    }
}
