using System;

namespace CallFire_csharp_sdk.Common.DataManagement
{
    public class CfBroadcast
    {
        public CfBroadcast(long id, string name, CfBroadcastStatus status, DateTime lastModified, CfBroadcastType type, CfBroadcastConfig item)
        {
            Id = id;
            Name = name;
            Status = status;
            LastModified = lastModified;
            Type = type;
            Item = item;
        }

        public string Name { get; set; }

        public CfBroadcastStatus Status { get; set; }

        public DateTime LastModified { get; set; }

        public CfBroadcastType Type { get; set; }

        public CfBroadcastConfig Item { get; set; }

        public long Id { get; set; }
    }

    public enum CfBroadcastStatus
    {
        StartPending,
        Running,
        Stopped,
        Finished,
        Archived
    }

    public enum CfBroadcastType
    {
        Voice,
        Ivr,
        Text
    }

    public class CfIvrBroadcastConfig : CfBroadcastConfig
    {
        public CfIvrBroadcastConfig(long identifier, DateTime created, string fromNumber, CfLocalTimeZoneRestriction localTimeZoneRestriction, CfBroadcastConfigRetryConfig retryConfig, string dialplanXml)
            : base(identifier, created, fromNumber, localTimeZoneRestriction, retryConfig)
        {
            DialplanXml = dialplanXml;
        }
        
        public string DialplanXml { get; set; }
    }

    public abstract class CfBroadcastConfig
    {
        protected CfBroadcastConfig()
        {
            Id = 0;
        }

        protected CfBroadcastConfig(long identifier, DateTime created, string fromNumber,
        CfLocalTimeZoneRestriction localTimeZoneRestriction, CfBroadcastConfigRetryConfig retryConfig)
        {
            Id = identifier;
            Created = created;
            FromNumber = fromNumber;
            LocalTimeZoneRestriction = localTimeZoneRestriction;
            RetryConfig = retryConfig;
        }

        public DateTime Created { get; set; }

        public string FromNumber { get; set; }

        public CfLocalTimeZoneRestriction LocalTimeZoneRestriction { get; set; }

        public CfBroadcastConfigRetryConfig RetryConfig { get; set; }

        public long Id { get; set; }
    }

    public class CfLocalTimeZoneRestriction
    {
        public CfLocalTimeZoneRestriction(DateTime beginTime, DateTime endTime)
        {
            BeginTime = beginTime;
            EndTime = endTime;
        }
        
        public DateTime BeginTime { get; set; }

        public DateTime EndTime { get; set; }
    }

    public class CfNumberOrderItem
    {
        public int Ordered { get; set; }

        public float UnitCost { get; set; }

        public string Fulfilled { get; set; }
    }

    public class CfToNumber
    {
        public string ClientData { get; set; }

        public System.Xml.XmlAttribute[] AnyAttr { get; set; }

        public string Value { get; set; }
    }

    public class CfAction
    {
        public string FromNumber { get; set; }

        public CfToNumber ToNumber { get; set; }

        public CfActionState State { get; set; }

        public long BatchId { get; set; }

        public long BroadcastId { get; set; }

        public long ContactId { get; set; }

        public bool Inbound { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public string FinalResult { get; set; }

        public CfLabel[] Label { get; set; }

        public long Id { get; set; }
    }

    public enum CfActionState
    {
        Ready,
        Selected,
        Finished,
        Dnc,
        Dup,
        Invalid,
        Timeout
    }

    public class CfLabel
    {
        public string Name { get; set; }
    }

    public abstract class CfActionRecord
    {
        public string Result { get; set; }

        public DateTime FinishTime { get; set; }

        public float BilledAmount { get; set; }

        public CfActionRecordQuestionResponse[] QuestionResponse { get; set; }

        public long Id { get; set; }
    }

    public class CfActionRecordQuestionResponse
    {
        public string Question { get; set; }

        public string Response { get; set; }
    }

    public abstract class CfInboundConfig
    {
        public long Id { get; set; }
    }

    public class CfBroadcastConfigRetryConfig
    {
        public CfBroadcastConfigRetryConfig()
        {
            MaxAttempts = 1;
            MinutesBetweenAttempts = 60;
        }

        public CfBroadcastConfigRetryConfig(int maxAttempts, int minutesBetweenAttempts, CfResult[] retryResults, CfRetryPhoneType[] retryPhoneTypes)
        {
            MaxAttempts = maxAttempts;
            MinutesBetweenAttempts = minutesBetweenAttempts;
            RetryResults = retryResults;
            RetryPhoneTypes = retryPhoneTypes;
        }
        
        public int MaxAttempts { get; set; }

        public int MinutesBetweenAttempts { get; set; }

        public CfResult[] RetryResults { get; set; }

        public CfRetryPhoneType[] RetryPhoneTypes { get; set; }
    }

    public class CfTextBroadcastConfig : CfBroadcastConfig
    {
        public CfTextBroadcastConfig()
        {
            BigMessageStrategy = CfBigMessageStrategy.SendMultiple;
        }
        
        public CfTextBroadcastConfig(long identifier, DateTime created, string fromNumber, CfLocalTimeZoneRestriction localTimeZoneRestriction, CfBroadcastConfigRetryConfig retryConfig, string message, CfBigMessageStrategy bigMessageStrategy)
            : base(identifier, created, fromNumber, localTimeZoneRestriction, retryConfig)
        {
            Message = message;
            BigMessageStrategy = bigMessageStrategy;
        }

        public string Message { get; set; }

        public CfBigMessageStrategy BigMessageStrategy { get; set; }
    }

    public enum CfResult
    {
        La,
        Am,
        Busy,
        Dnc,
        Xfer,
        XferLeg,
        NoAns,
        Undialed,
        Sent,
        Received,
        Dnt,
        TooBig,
        InternalError,
        CarrierError,
        CarrierTempError
    }

    public enum CfRetryPhoneType{
        FirstNumber,
        HomePhone,
        WorkPhone,
        MobilePhone
    }

    public enum CfBigMessageStrategy
    {
        SendMultiple,
        DoNotSend,
        Trim,
    }

    public class CfVoiceBroadcastConfig : CfBroadcastConfig
    {
        public CfVoiceBroadcastConfig(long identifier, DateTime created, string fromNumber,
        CfLocalTimeZoneRestriction localTimeZoneRestriction, CfBroadcastConfigRetryConfig retryConfig,
        CfAnsweringMachineConfig answeringMachineConfig, object item, string liveSoundTextVoice, object item1,
        string machineSoundTextVoice, object item2, string transferSoundTextVoice, string transferDigit,
        string transferNumber, object item3, string dncSoundTextVoice, string dncDigit, int maxActiveTransfers)
            : base(identifier, created, fromNumber, localTimeZoneRestriction, retryConfig)
        {
            AnsweringMachineConfig = answeringMachineConfig;
            Item = item;
            LiveSoundTextVoice = liveSoundTextVoice;
            Item1 = item1;
            MachineSoundTextVoice = machineSoundTextVoice;
            Item2 = item2;
            TransferSoundTextVoice = transferSoundTextVoice;
            TransferDigit = transferDigit;
            TransferNumber = transferNumber;
            Item3 = item3;
            DncSoundTextVoice = dncSoundTextVoice;
            DncDigit = dncDigit;
            MaxActiveTransfers = maxActiveTransfers;
        }
        
        public CfAnsweringMachineConfig AnsweringMachineConfig { get; set; }

        public object Item { get; set; }

        public string LiveSoundTextVoice { get; set; }

        public object Item1 { get; set; }

        public string MachineSoundTextVoice { get; set; }

        public object Item2 { get; set; }

        public string TransferSoundTextVoice { get; set; }

        public string TransferDigit { get; set; }

        public string TransferNumber { get; set; }

        public object Item3 { get; set; }

        public string DncSoundTextVoice { get; set; }

        public string DncDigit { get; set; }

        public int MaxActiveTransfers { get; set; }
    }

    public enum CfAnsweringMachineConfig
    {
        AmOnly,
        AmAndLive,
        LiveWithAmd,
        LiveImmediate
    }

    public class CfCallTrackingConfig : CfInboundConfig
    {
        public CfCallTrackingConfig()
        {
            Screen = false;
            Record = false;
        }

        public string TransferNumber { get; set; }

        public bool Screen { get; set; }

        public bool Record { get; set; }

        public long IntroSoundId { get; set; }

        public long WhisperSoundId { get; set; }
    }

    public class CfIvrInboundConfig : CfInboundConfig
    {
        public string DialplanXml { get; set; }
    }

    public class CfContactBatch
    {
        public CfContactBatch(long id, string name, CfBatchStatus status, long broadcastId, DateTime created, int size, int remaining)
        {
            Name = name;
            Status = status;
            BroadcastId = broadcastId;
            Created = created;
            Size = size;
            Remaining = remaining;
            Id = id;
        }
        
        public string Name { get; set; }

        public CfBatchStatus Status { get; set; }

        public long BroadcastId { get; set; }

        public DateTime Created { get; set; }

        public int Size { get; set; }

        public int Remaining { get; set; }

        public long Id { get; set; }
    }

    public enum CfBatchStatus
    {
        New,
        Validating,
        Errors,
        SourceError,
        Active
    }

    public class CfBroadcastSchedule
    {
        public DateTime StartTimeOfDay { get; set; }

        public DateTime StopTimeOfDay { get; set; }

        public string TimeZone { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }

        public CfDaysOfWeek[] DaysOfWeek { get; set; }

        public long Id { get; set; }

        public CfBroadcastSchedule(long identifier, DateTime startTimeOfDay, DateTime stopTimeOfDay, string timeZone, DateTime beginDate, DateTime endDate, CfDaysOfWeek[] daysOfWeek)
        {
            Id = identifier;
            StartTimeOfDay = startTimeOfDay;
            StopTimeOfDay = stopTimeOfDay;
            TimeZone = timeZone;
            BeginDate = beginDate;
            EndDate = endDate;
            DaysOfWeek = daysOfWeek;
        }
    }

    public enum CfDaysOfWeek
    {
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }

    public class CfBroadcastStats
    {
        public CfBroadcastStats(CfBroadcastStatsUsageStats usageStats, CfBroadcastStatsResultStat[] resultStat, CfBroadcastStatsActionStatistics actionStatistics)
        {
            UsageStats = usageStats;
            ResultStat = resultStat;
            ActionStatistics = actionStatistics;
        }
        
        public CfBroadcastStatsUsageStats UsageStats { get; set; }

        public CfBroadcastStatsResultStat[] ResultStat { get; set; }

        public CfBroadcastStatsActionStatistics ActionStatistics { get; set; }
    }

    public class CfBroadcastStatsUsageStats
    {
        public CfBroadcastStatsUsageStats(int duration, int billedDuration, float billedAmount,
        int attempts, int actions)
        {
            Duration = duration;
            BilledDuration = billedDuration;
            BilledAmount = billedAmount;
            Attempts = attempts;
            Actions = actions;
        }
        
        public int Duration { get; set; }

        public int BilledDuration { get; set; }

        public float BilledAmount { get; set; }

        public int Attempts { get; set; }

        public int Actions { get; set; }
    }

    public class CfBroadcastStatsResultStat
    {
        public CfBroadcastStatsResultStat(string result, int attempts, int actions)
        {
            Result = result;
            Attempts = attempts;
            Actions = actions;
        }
        
        public string Result { get; set; }

        public int Attempts { get; set; }

        public int Actions { get; set; }
    }

    public class CfBroadcastStatsActionStatistics
    {
        public CfBroadcastStatsActionStatistics(int unattempted, int retryWait, int finished)
        {
            Unattempted = unattempted;
            RetryWait = retryWait;
            Finished = finished;
        }
        
        public int Unattempted { get; set; }

        public int RetryWait { get; set; }

        public int Finished { get; set; }
    }

    public class CfCallRecord : CfActionRecord
    {
        public DateTime OriginateTime { get; set; }

        public DateTime AnswerTime { get; set; }

        public int Duration { get; set; }

        public CfRecordingMeta[] RecordingMeta { get; set; }
    }

    public class CfRecordingMeta
    {
        public string Name { get; set; }

        public DateTime Created { get; set; }

        public int LengthInSeconds { get; set; }

        public string Link { get; set; }

        public long Id { get; set; }
    }

    public class CfCall : CfAction
    {
        public CfCall(string fromNumber, CfToNumber toNumber, CfActionState state, long batchId, long broadcastId, long contactId, bool inbound,
            DateTime created, DateTime modified, string finalResult, CfLabel[] label, long Id, CfCallRecord[] callRecord)
        {
            CallRecord = callRecord;
        }

        public CfCallRecord[] CallRecord { get; set; }
    }

    public class CfSoundMeta
    {
        public CfSoundStatus Status { get; set; }

        public string Name { get; set; }

        public DateTime Created { get; set; }

        public int LengthInSeconds { get; set; }

        public long Id { get; set; }
    }

    public enum CfSoundStatus
    {
        Pending,
        Active,
        Failed,
        Archived
    }

    public class CfTextRecord : CfActionRecord
    {
        public string Message { get; set; }
    }

    public class CfText : CfAction
    {
        public string Message { get; set; }

        public CfTextRecord[] TextRecord { get; set; }
    }

    public class CfAutoReply
    {
        public string Number { get; set; }

        public string Keyword { get; set; }

        public string Match { get; set; }

        public string Message { get; set; }

        public long Id { get; set; }
    }

    public class CfSubscription
    {
        public CfSubscription(long id, bool enabled, string endpoint, CfNotificationFormat notificationFormat,
            CfSubscriptionTriggerEvent triggerEvent, CfSubscriptionSubscriptionFilter subscriptionFilter)
        {
            Id = id;
            Enabled = enabled;
            Endpoint = endpoint;
            NotificationFormat = notificationFormat;
            TriggerEvent = triggerEvent;
            SubscriptionFilter = subscriptionFilter;
        }

        public CfSubscription()
        {
            NotificationFormat = CfNotificationFormat.Xml;
        }

        public bool Enabled { get; set; }

        public string Endpoint { get; set; }

        public CfNotificationFormat NotificationFormat { get; set; }

        public CfSubscriptionTriggerEvent TriggerEvent { get; set; }

        public CfSubscriptionSubscriptionFilter SubscriptionFilter { get; set; }

        public long Id { get; set; }
    }

    public enum CfNotificationFormat
    {
        Xml,
        Json,
        Soap,
        Email
    }

    public enum CfSubscriptionTriggerEvent
    {
        UndefinedEvent,
        InboundCallFinished,
        InboundTextFinished,
        OutboundCallFinished,
        OutboundTextFinished,
        CampaignStarted,
        CampaignStopped,
        CampaignFinished
    }

    public class CfSubscriptionSubscriptionFilter
    {
        public CfSubscriptionSubscriptionFilter(long broadcastId, long batchId, string fromNumber, string toNumber, bool inbound)
        {
            BroadcastId = broadcastId;
            BatchId = batchId;
            FromNumber = fromNumber;
            ToNumber = toNumber;
            Inbound = inbound;
        }

        public long BroadcastId { get; set; }

        public long BatchId { get; set; }

        public string FromNumber { get; set; }

        public string ToNumber { get; set; }

        public bool Inbound { get; set; }

    }

    public class CfContact
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Zipcode { get; set; }

        public string HomePhone { get; set; }

        public string WorkPhone { get; set; }

        public string MobilePhone { get; set; }

        public string ExternalId { get; set; }

        public string ExternalSystem { get; set; }

        public System.Xml.XmlAttribute[] AnyAttr { get; set; }
    }

    public class CfContactHistory
    {
        public Action[] Items { get; set; }
    }

    public class CfContactList
    {
        public string Name { get; set; }

        public string Size { get; set; }

        public DateTime Created { get; set; }

        public CfContactListStatus Status { get; set; }

        public long Id { get; set; }
    }

    public enum CfContactListStatus
    {
        Active,
        Validating,
        Errors,
        Deleted,
        ParseFailed,
        ColumnTooLarge,
    }

    public class CfRegion
    {
        public string Prefix { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zipcode { get; set; }

        public string Country { get; set; }

        public string Lata { get; set; }

        public string RateCenter { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }

        public string TimeZone { get; set; }
    }

    public class CfLeaseInfo
    {
        public DateTime LeaseBegin { get; set; }

        public DateTime LeaseEnd { get; set; }

        public bool AutoRenew { get; set; }
    }

    public class CfNumber
    {
        public string Number1 { get; set; }

        public string NationalFormat { get; set; }

        public bool TollFree { get; set; }

        public CfRegion Region { get; set; }

        public CfNumberStatus Status { get; set; }

        public CfLeaseInfo LeaseInfo { get; set; }

        public CfNumberConfiguration NumberConfiguration { get; set; }
    }

    public enum CfNumberStatus
    {
        Pending,
        Active,
        Released,
        Unavailable
    }

    public class CfNumberConfiguration
    {
        public CfNumberFeature CallFeature { get; set; }

        public CfNumberFeature TextFeature { get; set; }

        public CfInboundType InboundCallConfigurationType { get; set; }

        public CfNumberConfigurationInboundCallConfiguration InboundCallConfiguration { get; set; }
    }

    public enum CfNumberFeature
    {
        Unsupported,
        Pending,
        Disabled,
        Enabled
    }

    public enum CfInboundType
    {
        Tracking,
        Ivr
    }

    public class CfNumberConfigurationInboundCallConfiguration
    {
        public CfInboundConfig Item { get; set; }
    }

    public class CfKeyword
    {
        public string ShortCode { get; set; }

        public string Keyword1 { get; set; }

        public CfNumberStatus Status { get; set; }

        public CfLeaseInfo LeaseInfo { get; set; }
    }

    public class CfNumberOrder
    {
        public CfOrderStatus Status { get; set; }

        public DateTime Created { get; set; }

        public float TotalCost { get; set; }

        public CfNumberOrderItem LocalNumbers { get; set; }

        public CfNumberOrderItem TollFreeNumbers { get; set; }

        public CfNumberOrderItem Keywords { get; set; }

        public long Id { get; set; }
    }

    public enum CfOrderStatus
    {
        New,
        Processing,
        Finished,
        Errored,
        Void,
        WaitForPayment,
        Adjusted
    }

}