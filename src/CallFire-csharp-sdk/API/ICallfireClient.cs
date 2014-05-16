namespace CallFire_csharp_sdk.API
{
    public interface ICallfireClient
    {
        IBroadcastClient Broadcasts { get; }

        ISubscriptionClient Subscription { get; }
    }
}
