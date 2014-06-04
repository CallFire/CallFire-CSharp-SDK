namespace CallFire_csharp_sdk.API
{
    public interface ICallfireClient
    {
        IBroadcastClient Broadcasts { get; }

        ISubscriptionClient Subscription { get; }

        ITextClient Text { get; }

        ICallClient Call { get; }

        INumberClient Number { get; }
    }
}
