namespace CallFire_csharp_sdk.API.Soap
{
    public interface ICallServicePortTypeClient : IServicePortClient
    {
        long SendCall(SendCall sendCall1);
        CallQueryResult QueryCalls(ActionQuery queryCalls1);
        Call GetCall(IdRequest getCall1);
        long CreateSound(CreateSound createSound1);
        SoundMetaQueryResult QuerySoundMeta(Query querySoundMeta1);
        SoundMeta GetSoundMeta(IdRequest getSoundMeta1);
    }
}
