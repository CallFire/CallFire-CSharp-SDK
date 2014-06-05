namespace CallFire_csharp_sdk.API
{
    public interface ICallfireClient
    {
        IBroadcastClient Broadcasts { get; }

        ISubscriptionClient Subscription { get; }

        ITextClient Text { get; }

        ICallClient Call { get; }

        IContactClient Contact { get; }

        INumberClient Number { get; }

        ILabelClient Label { get; }
    }
}
