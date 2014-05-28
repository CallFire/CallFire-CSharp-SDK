namespace CallFire_csharp_sdk.API.Soap
{
    public interface ICallServicePortTypeClient : IServicePortClient
    {
        long SendCall(SendCall sendCall1);
        CallQueryResult QueryCalls(ActionQuery queryCalls1);
        Call GetCall(IdRequest getCall1);
    }
}
