namespace CallFire_csharp_sdk.Common.Client
{
    public abstract class ClientBase
    {
        public abstract string Ns();

        public abstract void Request(object type);

        public abstract void Response(object data);

        public const string AMCONFIG_AM_ONLY = "AM_ONLY";
        public const string AMCONFIG_AM_AND_LIVE = "AM_AND_LIVE";
        public const string AMCONFIG_LIVE_WITH_AMD = "LIVE_WITH_AMD";
        public const string AMCONFIG_LIVE_IMMEDIATE = "LIVE_IMMEDIATE";

        public const string BROADCAST_VOICE = "VOICE";
        public const string BROADCAST_IVR = "IVR";
        public const string BROADCAST_TEXT = "TEXT";

        public const string COMMAND_START = "START";
        public const string COMMAND_STOP = "STOP";
        public const string COMMAND_ARCHIVE = "ARCHIVE";

        public const string EVENT_UNDEFINED_EVENT = "UNDEFINED_EVENT";
        public const string EVENT_INBOUND_CALL_FINISHED = "INBOUND_CALL_FINISHED";
        public const string EVENT_INBOUND_TEXT_FINISHED = "INBOUND_TEXT_FINISHED";
        public const string EVENT_OUTBOUND_CALL_FINISHED = "OUTBOUND_CALL_FINISHED";
        public const string EVENT_OUTBOUND_TEXT_FINISHED = "OUTBOUND_TEXT_FINISHED";
        public const string EVENT_CAMPAIGN_STARTED = "CAMPAIGN_STARTED";
        public const string EVENT_CAMPAIGN_STOPPED = "CAMPAIGN_STOPPED";
        public const string EVENT_CAMPAIGN_FINISHED = "CAMPAIGN_FINISHED";

        public const string FEATURE_UNSUPPORTED = "UNSUPPORTED";
        public const string FEATURE_PENDING = "PENDING";
        public const string FEATURE_DISABLED = "DISABLED";
        public const string FEATURE_ENABLED = "ENABLED";

        public const string FORMAT_XML = "XML";
        public const string FORMAT_JSON = "JSON";
        public const string FORMAT_SOAP = "SOAP";
        public const string FORMAT_EMAIL = "EMAIL";

        public const string INBOUND_TRACKING = "TRACKING";
        public const string INBOUND_IVR = "IVR";

        public const string RESULT_ANSWER_MACHINE = "AM";
        public const string RESULT_BUSY = "BUSY";
        public const string RESULT_DO_NOT_CALL = "DNC";
        public const string RESULT_TRANSFER = "XFER";
        public const string RESULT_TRANSFER_LEG = "XFER_LEG";
        public const string RESULT_NO_ANSWER = "NO_ANS";
        public const string RESULT_UNDIALED = "UNDIALED";
        public const string RESULT_SENT = "SENT";
        public const string RESULT_RECEIVED = "RECEIVED";
        public const string RESULT_DID_NOT_TRY = "DNT";
        public const string RESULT_TOO_BIG = "TOO_BIG";
        public const string RESULT_INTERNAL_ERROR = "INTERNAL_ERROR";
        public const string RESULT_CARRIER_ERROR = "CARRIER_ERROR";
        public const string RESULT_CARRIER_TEMP_ERROR = "CARRIER_TEMP_ERROR";

        public const string STATE_READY = "READY";
        public const string STATE_SELECTED = "SELECTED";
        public const string STATE_FINISHED = "FINISHED";
        public const string STATE_DO_NOT_CALL = "DNC";
        public const string STATE_DUPLICATE = "DUP";
        public const string STATE_INVALID = "INVALID";
        public const string STATE_TIMEOUT = "TIMEOUT";

        public const string STRATEGY_SEND_MULTIPLE = "SEND_MULTIPLE";
        public const string STRATEGY_DO_NOT_SEND = "DO_NOT_SEND";
        public const string STRATEGY_TRIM = "TRIM";
    }
}
