using System;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.Resource.Mappers;

namespace CallFire_csharp_sdk.Common.DataManagement
{
    public class CfBroadcast
    {
        public CfBroadcast(long? id, string name, CfBroadcastStatus? status, DateTime? lastModified, CfBroadcastType? type, CfBroadcastConfig item)
        {
            Id = id;
            Name = name;
            Status = status;
            LastModified = lastModified;
            Type = type;
            Item = item;
        }

        /// <summary>
        /// Name of Broadcast
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Status of Broadcast [StartPending, Running, Stopped, Finished, Archived]
        /// </summary>
        public CfBroadcastStatus? Status { get; set; }

        /// <summary>
        /// Last Modified
        /// </summary>
        public DateTime? LastModified { get; set; }

        /// <summary>
        /// Type of Broadcast [Voice, Ivr, Text]
        /// </summary>
        public CfBroadcastType? Type { get; set; }

        /// <summary>
        /// Configuration needed
        /// </summary>
        public CfBroadcastConfig Item { get; set; }

        /// <summary>
        /// Unique ID of Broadcast
        /// </summary>
        public long? Id { get; set; }
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
        
        /// <summary>
        /// IVR xml document describing dialplan
        /// </summary>
        public string DialplanXml { get; set; }
    }

    public abstract class CfBroadcastConfig
    {
        protected CfBroadcastConfig()
        {
            Id = 0;
        }

        protected CfBroadcastConfig(long? identifier, DateTime? created, string fromNumber,
        CfLocalTimeZoneRestriction localTimeZoneRestriction, CfBroadcastConfigRetryConfig retryConfig)
        {
            Id = identifier;
            Created = created;
            FromNumber = fromNumber;
            LocalTimeZoneRestriction = localTimeZoneRestriction;
            RetryConfig = retryConfig;
        }

        /// <summary>
        /// DateTime Broadcast was created
        /// </summary>
        public DateTime? Created { get; set; }

        /// <summary>
        /// E.164 11 digit number or short code
        /// </summary>
        public string FromNumber { get; set; }

        /// <summary>
        /// Restrict the times your compaign can run
        /// </summary>
        public CfLocalTimeZoneRestriction LocalTimeZoneRestriction { get; set; }

        /// <summary>
        /// Retry logic for broadcast
        /// </summary>
        public CfBroadcastConfigRetryConfig RetryConfig { get; set; }

        /// <summary>
        /// Unique ID of BroadcastConfig
        /// </summary>
        public long? Id { get; set; }
    }

    public class CfLocalTimeZoneRestriction
    {
        public CfLocalTimeZoneRestriction(DateTime? beginTime, DateTime? endTime)
        {
            BeginTime = beginTime;
            EndTime = endTime;
        }
        
        /// <summary>
        /// Earliest time a client can be contacted in the timezone associated with the number's NPA/NXX
        /// </summary>
        public DateTime? BeginTime { get; set; }

        /// <summary>
        /// Latest time a client can be contacted in the timezone associated with the number's NPA/NXX
        /// </summary>
        public DateTime? EndTime { get; set; }
    }

    public class CfNumberOrderItem
    {
        public CfNumberOrderItem(int ordered, float unitCost, string fulfilled)
        {
            Ordered = ordered;
            UnitCost = unitCost;
            Fulfilled = fulfilled;
        }

        public int Ordered { get; set; }

        public float UnitCost { get; set; }

        public string Fulfilled { get; set; }
    }

    public class CfToNumber
    {
        public CfToNumber(string clientData, System.Xml.XmlAttribute[] anyAttr, string value)
        {
            ClientData = clientData;
            AnyAttr = anyAttr;
            Value = value;
        }

        public string ClientData { get; set; }

        public System.Xml.XmlAttribute[] AnyAttr { get; set; }

        public string Value { get; set; }
    }

    public class CfAction
    {
        public CfAction(string fromNumber, CfToNumber toNumber, CfActionState state, long? batchId, long? broadcastId, long contactId,
            bool inbound, DateTime created, DateTime modified, CfResult finalResult, CfLabel[] label, long id)
        {
            FromNumber = fromNumber;
            ToNumber = toNumber;
            State = state;
            BatchId = batchId;
            BroadcastId = broadcastId;
            ContactId = contactId;
            Inbound = inbound;
            Created = created;
            Modified = modified;
            FinalResult = finalResult;
            Label = label;
            Id = id;
        }
        
        public CfAction()
        {
        }

        /// <summary>
        /// E.164 11 digit number or short code
        /// </summary>
        public string FromNumber { get; set; }

        /// <summary>
        /// E.164 11 digit numbers 
        /// </summary>
        public CfToNumber ToNumber { get; set; }

        /// <summary>
        /// Current State of Action
        /// </summary>
        public CfActionState State { get; set; }

        /// <summary>
        /// Unique ID of Batch associated with Action
        /// </summary>
        public long? BatchId { get; set; }

        /// <summary>
        /// Unique ID of Broadcast associated with Action
        /// </summary>
        public long? BroadcastId { get; set; }

        /// <summary>
        /// Unique ID of Contact associated with Action
        /// </summary>
        public long ContactId { get; set; }

        /// <summary>
        /// Is inbound Action
        /// </summary>
        public bool Inbound { get; set; }

        /// <summary>
        /// DateTime Action was created 
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// DateTime Action was modified 
        /// </summary>
        public DateTime Modified { get; set; }

        public CfResult FinalResult { get; set; }

        public CfLabel[] Label { get; set; }

        /// <summary>
        /// Unique ID of action
        /// </summary>
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
        public CfLabel(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }

    public abstract class CfActionRecord
    {
        protected CfActionRecord(CfResult result, DateTime finishTime, float billedAmount, CfActionRecordQuestionResponse[] questionResponse, long id)
        {
            Result = result;
            FinishTime = finishTime;
            BilledAmount = billedAmount;
            QuestionResponse = questionResponse;
            Id = id;
        }

        protected CfActionRecord()
        {
        }

        public CfResult Result { get; set; }

        /// <summary>
        /// DateTime action finished
        /// </summary>
        public DateTime FinishTime { get; set; }

        /// <summary>
        /// Credits charged for call or text
        /// </summary>
        public float BilledAmount { get; set; }

        /// <summary>
        /// Question / Response pair defined in IVR campaign with 'stash'.
        /// </summary>
        public CfActionRecordQuestionResponse[] QuestionResponse { get; set; }

        public long Id { get; set; }
    }

    public class CfActionRecordQuestionResponse
    {
        public CfActionRecordQuestionResponse(string question, string response)
        {
            Question = question;
            Response = response;
        }

        /// <summary>
        /// IVR stash 'varname'
        /// </summary>
        public string Question { get; set; }

        /// <summary>
        /// IVR stash value associated with 'varname'
        /// </summary>
        public string Response { get; set; }
    }

    public abstract class CfInboundConfig
    {
        /// <summary>
        /// Unique ID of InboundConfig
        /// </summary>
        public long? Id { get; set; }
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
        
        /// <summary>
        /// Max attempts to retry broadcast (default: 1)
        /// </summary>
        public int MaxAttempts { get; set; }

        /// <summary>
        /// Minutes between broadcast attempts (default: 60)
        /// </summary>
        public int MinutesBetweenAttempts { get; set; }

        /// <summary>
        /// Conditions to retry on [La, Am, Busy, Dnc, Xfer, XferLeg, NoAns, Undialed, Sent, 
        /// Received, Dnt, TooBig, InternalError, CarrierError, CarrierTempError]
        /// </summary>
        public CfResult[] RetryResults { get; set; }

        /// <summary>
        /// Phone types to call in retry [FirstNumber, HomePhone, WorkPhone, MobilePhone]
        /// </summary>
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

        /// <summary>
        /// 160 char or less message to be sent in text broadcast. Use rented 'keyword' in message if need response
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Set strategy if message is over 160 chars (default: SEND_MULTIPLE) 
        /// [SendMultiple, DoNotSend, Trim,]
        /// </summary>
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

    public enum CfSoundFormat
    {
        Wav,
        Mp3
    }

    public enum CfItemsChoiceType
    {
        CallId,
        Name,
        RecordingId
    }

    public class CfVoiceBroadcastConfig : CfBroadcastConfig
    {
        public CfVoiceBroadcastConfig(long identifier, DateTime created, string fromNumber,
        CfLocalTimeZoneRestriction localTimeZoneRestriction, CfBroadcastConfigRetryConfig retryConfig,
        CfAnsweringMachineConfig? answeringMachineConfig, object item, string liveSoundTextVoice, object item1,
        string machineSoundTextVoice, object item2, string transferSoundTextVoice, string transferDigit,
        string transferNumber, object item3, string dncSoundTextVoice, string dncDigit, int? maxActiveTransfers)
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
        
        /// <summary>
        /// Action to take if machine answers [AmOnly, AmAndLive, LiveWithAmd, LiveImmediate]
        /// </summary>
        public CfAnsweringMachineConfig? AnsweringMachineConfig { get; set; }

        public object Item { get; set; }

        public string LiveSoundTextVoice { get; set; }

        public object Item1 { get; set; }

        public string MachineSoundTextVoice { get; set; }

        public object Item2 { get; set; }

        public string TransferSoundTextVoice { get; set; }

        /// <summary>
        /// Phone digit call transfers on if pressed
        /// </summary>
        public string TransferDigit { get; set; }

        /// <summary>
        /// Number to transfer call to
        /// </summary>
        public string TransferNumber { get; set; }

        public object Item3 { get; set; }

        public string DncSoundTextVoice { get; set; }

        /// <summary>
        /// Do Not Call Digit
        /// </summary>
        public string DncDigit { get; set; }

        /// <summary>
        /// Max Transfers
        /// </summary>
        public int? MaxActiveTransfers { get; set; }
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
        
        public CfCallTrackingConfig(long? id, string transferNumber, bool screen, bool record, long? introSoundId, long? whisperSoundId)
        {
            Id = id;
            TransferNumber = transferNumber;
            Screen = screen;
            Record = record;
            IntroSoundId = introSoundId;
            WhisperSoundId = whisperSoundId;
        }

        public string TransferNumber { get; set; }

        public bool Screen { get; set; }

        public bool Record { get; set; }

        public long? IntroSoundId { get; set; }

        public long? WhisperSoundId { get; set; }
    }

    public class CfIvrInboundConfig : CfInboundConfig
    {
        public CfIvrInboundConfig(long? id, string dialplanXml)
        {
            Id = id;
            DialplanXml = dialplanXml;
        }

        public string DialplanXml { get; set; }
    }

    public class CfContactBatch
    {
        public CfContactBatch(long id, string name, CfBatchStatus status, long broadcastId, DateTime created, int? size, int? remaining)
        {
            Name = name;
            Status = status;
            BroadcastId = broadcastId;
            Created = created;
            Size = size;
            Remaining = remaining;
            Id = id;
        }
        
        /// <summary>
        /// Name of Contact Batch
        /// </summary>
        public string Name { get; set; }

        public CfBatchStatus Status { get; set; }

        /// <summary>
        /// ID of Broadcast this Batch is attached to
        /// </summary>
        public long BroadcastId { get; set; }

        public DateTime Created { get; set; }

        /// <summary>
        /// Contact count in this Batch
        /// </summary>
        public int? Size { get; set; }

        public int? Remaining { get; set; }

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
        public CfBroadcastSchedule(long? identifier, DateTime startTimeOfDay, DateTime stopTimeOfDay, string timeZone, 
            DateTime? beginDate, DateTime? endDate, CfDaysOfWeek[] daysOfWeek)
        {
            Id = identifier;
            StartTimeOfDay = startTimeOfDay;
            StopTimeOfDay = stopTimeOfDay;
            TimeZone = timeZone;
            BeginDate = beginDate;
            EndDate = endDate;
            DaysOfWeek = daysOfWeek;
        }

        /// <summary>
        /// Earliest time a client can be contacted in the timezone associated with the number's NPA/NXX
        /// </summary>
        public DateTime StartTimeOfDay { get; set; }

        /// <summary>
        /// Latest time a client can be contacted in the timezone associated with the number's NPA/NXX
        /// </summary>
        public DateTime StopTimeOfDay { get; set; }

        /// <summary>
        /// Time Zone
        /// </summary>
        public string TimeZone { get; set; }

        /// <summary>
        /// Start date of Campaign
        /// </summary>
        public DateTime? BeginDate { get; set; }

        /// <summary>
        /// End date of Campaign
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// List of days of week [Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday]
        /// </summary>
        public CfDaysOfWeek[] DaysOfWeek { get; set; }

        /// <summary>
        /// Unique ID of Broadcast Schedule
        /// </summary>
        public long? Id { get; set; }
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
        
        /// <summary>
        /// Duration of calls in seconds
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Duration of calls billed in seconds
        /// </summary>
        public int BilledDuration { get; set; }

        /// <summary>
        /// Billed credits
        /// </summary>
        public float BilledAmount { get; set; }

        /// <summary>
        /// Attempted Texts and Calls
        /// </summary>
        public int Attempts { get; set; }

        /// <summary>
        /// Text and Calls placed
        /// </summary>
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
        public CfCallRecord(CfResult result, DateTime finishTime, float billedAmount, CfActionRecordQuestionResponse[] questionResponse, long id,
            DateTime? originateTime, DateTime? answerTime, int duration, CfRecordingMeta[] recordingMeta)
            : base(result, finishTime, billedAmount, questionResponse, id)
        {
            OriginateTime = originateTime;
            AnswerTime = answerTime;
            Duration = duration;
            RecordingMeta = recordingMeta;
        }

        public DateTime? OriginateTime { get; set; }

        public DateTime? AnswerTime { get; set; }

        public int Duration { get; set; }

        public CfRecordingMeta[] RecordingMeta { get; set; }
    }

    public class CfRecordingMeta
    {
        public CfRecordingMeta(string name, DateTime created, int lengthInSeconds, string link, long id)
        {
            Name = name;
            Created = created;
            LengthInSeconds = lengthInSeconds;
            Link = link;
            Id = id;
        }

        public string Name { get; set; }

        public DateTime Created { get; set; }

        public int LengthInSeconds { get; set; }

        public string Link { get; set; }

        public long Id { get; set; }
    }

    public class CfCall : CfAction
    {
        public CfCall(string fromNumber, CfToNumber toNumber, CfActionState state, long batchId, long broadcastId, long contactId, bool inbound,
            DateTime created, DateTime modified, CfResult finalResult, CfLabel[] label, long id, CfCallRecord[] callRecord)
            : base(fromNumber, toNumber, state, batchId, broadcastId, contactId, inbound, created, modified, finalResult, label, id)
        {
            CallRecord = callRecord;
        }

        public CfCallRecord[] CallRecord { get; set; }
    }

    public class CfSoundMeta
    {
        public CfSoundMeta(CfSoundStatus status, string name, DateTime created, int? lengthInSeconds, long id)
        {
            Status = status;
            Name = name;
            Created = created;
            LengthInSeconds = lengthInSeconds;
            Id = id;
        }

        /// <summary>
        /// Status [Pending, Active, Failed, Archived]
        /// </summary>
        public CfSoundStatus Status { get; set; }

        /// <summary>
        /// Name of sound meta
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// DateTime when sound was created
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Duration of stored sound in seconds
        /// </summary>
        public int? LengthInSeconds { get; set; }

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
        public CfTextRecord(CfResult result, DateTime finishTime, float billedAmount, CfActionRecordQuestionResponse[] questionResponse, long id, string message)
            : base(result, finishTime, billedAmount, questionResponse, id)
        {
            Message = message;
        }

        public string Message { get; set; }
    }

    public class CfText : CfAction
    {
        public CfText(string fromNumber, CfToNumber toNumber, CfActionState state, long batchId, long broadcastId, long contactId,
            bool inbound, DateTime created, DateTime modified, CfResult finalResult, CfLabel[] label, long id, string message, CfTextRecord[] textRecord) 
            : base(fromNumber, toNumber, state, batchId, broadcastId, contactId, inbound, created, modified, finalResult, label, id)
        {
            Message = message;
            TextRecord = textRecord;
        }

        public string Message { get; set; }

        public CfTextRecord[] TextRecord { get; set; }
    }

    public class CfAutoReply
    {
        public CfAutoReply(string number, string keyword, string match, string message, long? id)
        {
            Number = number;
            Keyword = keyword;
            Match = match;
            Message = message;
            Id = id;
        }

        /// <summary>
        /// Phone number to configure an auto reply message
        /// </summary>
        public string Number { get; set; }

        public string Keyword { get; set; }

        public string Match { get; set; }

        public string Message { get; set; }

        /// <summary>
        /// Unique ID of Text Auto Reply
        /// </summary>
        public long? Id { get; set; }
    }

    public class CfSubscription
    {
        public CfSubscription(long? id, bool? enabled, string endpoint, CfNotificationFormat notificationFormat,
            CfSubscriptionTriggerEvent? triggerEvent, CfSubscriptionSubscriptionFilter subscriptionFilter)
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

        /// <summary>
        /// Enable publishing of postback notifications for subscribed events
        /// </summary>
        public bool? Enabled { get; set; }

        /// <summary>
        /// Email or URI endpoint to publish notification event to
        /// </summary>
        public string Endpoint { get; set; }

        /// <summary>
        /// [Xml, Json, Soap, Email]
        /// </summary>
        public CfNotificationFormat NotificationFormat { get; set; }

        /// <summary>
        /// Event to trigger on [UndefinedEvent, InboundCallFinished, InboundTextFinished, OutboundCallFinished, 
        /// OutboundTextFinished, CampaignStarted, CampaignStopped, CampaignFinished]
        /// </summary>
        public CfSubscriptionTriggerEvent? TriggerEvent { get; set; }

        /// <summary>
        /// Filter the type of notification events published to postback URI endpoint.
        /// </summary>
        public CfSubscriptionSubscriptionFilter SubscriptionFilter { get; set; }

        /// <summary>
        /// Unique ID of Subscription
        /// </summary>
        public long? Id { get; set; }
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

        /// <summary>
        /// Broadcast ID to filter on
        /// </summary>
        public long BroadcastId { get; set; }

        /// <summary>
        /// Batch ID to filter on
        /// </summary>
        public long BatchId { get; set; }

        /// <summary>
        /// From number (11 digit) or shortcode to filter on
        /// </summary>
        public string FromNumber { get; set; }

        /// <summary>
        /// E.164 11 digit phone number
        /// </summary>
        public string ToNumber { get; set; }

        /// <summary>
        /// Deprecated, use TriggerEvent
        /// </summary>
        public bool Inbound { get; set; }

    }

    public class CfContact
    {
        public CfContact()
        {
        }

        public CfContact(long? id, string firstName, string lastName, string zipcode, string homePhone, string workPhone, string mobilePhone,
            string externalId, string externalSystem, System.Xml.XmlAttribute[] anyAttr)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Zipcode = zipcode;
            HomePhone = homePhone;
            WorkPhone = workPhone;
            MobilePhone = mobilePhone;
            ExternalId = externalId;
            ExternalSystem = externalSystem;
            AnyAttr = anyAttr;
        }

        /// <summary>
        /// Unique ID of Contact
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// First name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// 5 digit zipcode
        /// </summary>
        public string Zipcode { get; set; }

        /// <summary>
        /// E.164 11 digit number
        /// </summary>
        public string HomePhone { get; set; }

        /// <summary>
        /// E.164 11 digit number
        /// </summary>
        public string WorkPhone { get; set; }

        /// <summary>
        /// E.164 11 digit number
        /// </summary>
        public string MobilePhone { get; set; }

        /// <summary>
        /// id of contact defined by external system (NATION_BUILDER, GOOGLE_GROUPS, etc...)
        /// </summary>
        public string ExternalId { get; set; }

        /// <summary>
        /// System where externalId was generated from (NATION_BUILDER, GOOGLE_GROUPS, etc...)
        /// </summary>
        public string ExternalSystem { get; set; }

        public System.Xml.XmlAttribute[] AnyAttr { get; set; }
    }

    public class CfContactHistory
    {
        public CfAction[] Items { get; set; }
    }

    public class CfContactList
    {
        public CfContactList(ContactList source)
        {
            Name = source.Name;
            Size = source.Size;
            Created = source.Created;
            Status = EnumeratedMapper.EnumFromSoapEnumerated<CfContactListStatus>(source.Status.ToString());
            Id = source.id;
        }

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
        public CfRegion(string prefix, string city, string state, string zipcode, string country, string lata, 
            string rateCenter, float? latitude, float? longitude, string timeZone)
        {
            Prefix = prefix;
            City = city;
            State = state;
            Zipcode = zipcode;
            Country = country;
            Lata = lata;
            RateCenter = rateCenter;
            Latitude = latitude;
            Longitude = longitude;
            TimeZone = timeZone;
        }

        /// <summary>
        /// 4-7 digit prefix
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// Name of a city
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// State abbreviation
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// 5 digit zipcode
        /// </summary>
        public string Zipcode { get; set; }

        /// <summary>
        /// 2 digit country code
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Lata
        /// </summary>
        public string Lata { get; set; }

        public string RateCenter { get; set; }

        /// <summary>
        /// Latitude
        /// </summary>
        public float? Latitude { get; set; }

        /// <summary>
        /// Longitude
        /// </summary>
        public float? Longitude { get; set; }

        public string TimeZone { get; set; }
    }

    public class CfLeaseInfo
    {
        public CfLeaseInfo(DateTime? leaseBegin, DateTime? leaseEnd, bool autoRenew)
        {
            LeaseBegin = leaseBegin;
            LeaseEnd = leaseEnd;
            AutoRenew = autoRenew;
        }

        /// <summary>
        /// Date lease began
        /// </summary>
        public DateTime? LeaseBegin { get; set; }

        /// <summary>
        /// Date lease ends
        /// </summary>
        public DateTime? LeaseEnd { get; set; }

        /// <summary>
        /// Is lease set to renew each month
        /// </summary>
        public bool AutoRenew { get; set; }
    }

    public class CfNumber
    {
        public CfNumber(string number1, string nationalFormat, bool tollFree, CfRegion region, CfNumberStatus? status, 
            CfLeaseInfo leaseInfo, CfNumberConfiguration numberConfiguration)
        {
            Number1 = number1;
            NationalFormat = nationalFormat;
            TollFree = tollFree;
            Region = region;
            Status = status;
            LeaseInfo = leaseInfo;
            NumberConfiguration = numberConfiguration;
        }

        /// <summary>
        /// 11 digit E.164 number
        /// </summary>
        public string Number1 { get; set; }

        /// <summary>
        /// Phone number formatted for local
        /// </summary>
        public string NationalFormat { get; set; }

        /// <summary>
        /// Is toll free number
        /// </summary>
        public bool TollFree { get; set; }

        /// <summary>
        /// Region of number represented by city, state, prefix, etc..
        /// </summary>
        public CfRegion Region { get; set; }

        /// <summary>
        /// Status [Pending, Active, Released, Unavailable]
        /// </summary>
        public CfNumberStatus? Status { get; set; }

        /// <summary>
        /// Info about Lease
        /// </summary>
        public CfLeaseInfo LeaseInfo { get; set; }

        /// <summary>
        /// Configure Call and Text features
        /// </summary>
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
        public CfNumberConfiguration(CfNumberFeature? callFeature, CfNumberFeature? textFeature, CfInboundType? inboundCallConfigurationType,
            CfNumberConfigurationInboundCallConfiguration inboundCallConfiguration)
        {
            CallFeature = callFeature;
            TextFeature = textFeature;
            InboundCallConfigurationType = inboundCallConfigurationType;
            InboundCallConfiguration = inboundCallConfiguration;
        }

        /// <summary>
        /// [Unsupported, Pending, Disabled, Enabled]
        /// </summary>
        public CfNumberFeature? CallFeature { get; set; }

        /// <summary>
        /// [Unsupported, Pending, Disabled, Enabled]
        /// </summary>
        public CfNumberFeature? TextFeature { get; set; }

        /// <summary>
        /// [Tracking, Ivr]
        /// </summary>
        public CfInboundType? InboundCallConfigurationType { get; set; }

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
        public CfNumberConfigurationInboundCallConfiguration(CfInboundConfig item)
        {
            Item = item;
        }

        public CfInboundConfig Item { get; set; }
    }

    public class CfKeyword
    {
        public CfKeyword(string shortCode, string keyword1, CfNumberStatus? status, CfLeaseInfo leaseInfo)
        {
            ShortCode = shortCode;
            Keyword1 = keyword1;
            Status = status;
            LeaseInfo = leaseInfo;
        }

        public string ShortCode { get; set; }

        public string Keyword1 { get; set; }

        public CfNumberStatus? Status { get; set; }

        public CfLeaseInfo LeaseInfo { get; set; }
    }

    public class CfNumberOrder
    {
        public CfNumberOrder(CfOrderStatus status, DateTime created, float totalCost, CfNumberOrderItem localNumbers,
            CfNumberOrderItem tollFreeNumbers, CfNumberOrderItem keywords, long id)
        {
            Status = status;
            Created = created;
            TotalCost = totalCost;
            LocalNumbers = localNumbers;
            TollFreeNumbers = tollFreeNumbers;
            Keywords = keywords;
            Id = id;
        }

        /// <summary>
        /// Status [New, Processing, Finished, Errored, Void, WaitForPayment, Adjusted]
        /// </summary>
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