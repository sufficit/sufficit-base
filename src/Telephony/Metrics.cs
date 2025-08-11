namespace Sufficit.Telephony
{
    /// <summary>
    /// Category constants for telephony metrics
    /// </summary>
    public static class TelephonyMetrics
    {
        /// <summary>
        /// Main category for all telephony metrics
        /// </summary>
        public const string Category = "telephony";
    }
    
    /// <summary>
    /// Subtypes for telephony_calls category
    /// </summary>
    public static class TelephonyMetricSubtypes
    {
        public const string Inbound = "inbound";
        public const string Outbound = "outbound";
        public const string Internal = "internal";
        public const string Conference = "conference";
        public const string Transfer = "transfer";
        public const string All = "all";
        public const string Default = "default";
    }
    
    /// <summary>
    /// Common metric names for telephony calls with telephony_call_ prefix
    /// </summary>
    public static class TelephonyCallMetrics
    {
        // Basic call count metrics
        
        /// <summary>
        /// Total number of calls in the time period.
        /// Calculation: COUNT(*) of all calls grouped by LinkedId (unique calls)
        /// </summary>
        public const string TotalCalls = "telephony_call_total";
        
        /// <summary>
        /// Number of incoming calls (direction = INCOMING).
        /// Calculation: COUNT(*) WHERE Direction = CallDirection.INCOMING
        /// </summary>
        public const string IncomingCalls = "telephony_call_incoming";
        
        /// <summary>
        /// Number of outbound calls (direction = OUTBOUND).
        /// Calculation: COUNT(*) WHERE Direction = CallDirection.OUTBOUND
        /// </summary>
        public const string OutboundCalls = "telephony_call_outbound";
        
        /// <summary>
        /// Number of answered calls (disposition = ANSWERED).
        /// Calculation: COUNT(*) WHERE Disposition = TelephonyCallDisposition.ANSWERED
        /// </summary>
        public const string AnsweredCalls = "telephony_call_answered";
        
        /// <summary>
        /// Number of abandoned/unanswered calls (disposition != ANSWERED).
        /// Calculation: COUNT(*) WHERE Disposition != TelephonyCallDisposition.ANSWERED
        /// </summary>
        public const string AbandonedCalls = "telephony_call_abandoned";
        
        /// <summary>
        /// Number of missed calls (not answered calls).
        /// Calculation: COUNT(*) WHERE Disposition = TelephonyCallDisposition.NO_ANSWER or similar
        /// </summary>
        public const string MissedCalls = "telephony_call_missed";
        
        // Call duration metrics
        
        /// <summary>
        /// Average call duration in seconds for answered calls.
        /// Calculation: AVG(Extra.Duration) WHERE Extra.Duration > 0 AND Disposition = ANSWERED
        /// </summary>
        public const string DurationAvg = "telephony_call_duration_avg";
        
        /// <summary>
        /// Maximum call duration in seconds in the time period.
        /// Calculation: MAX(Extra.Duration) WHERE Extra.Duration > 0
        /// </summary>
        public const string DurationMax = "telephony_call_duration_max";
        
        /// <summary>
        /// Minimum call duration in seconds in the time period.
        /// Calculation: MIN(Extra.Duration) WHERE Extra.Duration > 0
        /// </summary>
        public const string DurationMin = "telephony_call_duration_min";
        
        /// <summary>
        /// Total call duration in seconds for all answered calls.
        /// Calculation: SUM(Extra.Duration) WHERE Extra.Duration > 0
        /// </summary>
        public const string DurationTotal = "telephony_call_duration_total";
        
        // Business metrics
        
        /// <summary>
        /// Business hours indicator (1 if during business hours, 0 otherwise).
        /// Calculation: timestamp.Hour &gt;= 8 &amp;&amp; timestamp.Hour &lt; 18 ? 1 : 0
        /// </summary>
        public const string BusinessHours = "telephony_call_business_hours";
        
        /// <summary>
        /// Week number of the year (1-53).
        /// Calculation: Calendar.GetWeekOfYear(timestamp, CalendarWeekRule, DayOfWeek.Monday)
        /// </summary>
        public const string WeekNumber = "telephony_call_week_number";
        
        /// <summary>
        /// Ratio of weekday calls vs weekend calls (0.0 to 1.0).
        /// Calculation: COUNT(calls on weekdays) / COUNT(total calls)
        /// </summary>
        public const string WeekdayRatio = "telephony_call_weekday_ratio";
        
        // Rate and performance metrics
        
        /// <summary>
        /// Answer rate percentage (answered calls / total calls * 100).
        /// Calculation: (COUNT(answered calls) / COUNT(total calls)) * 100
        /// </summary>
        public const string AnswerRate = "telephony_call_answer_rate";
        
        /// <summary>
        /// Calls per hour rate based on time period duration.
        /// Calculation: (COUNT(calls) / time_period_hours) rounded to 2 decimals
        /// </summary>
        public const string CallsPerHour = "telephony_call_calls_per_hour";
        
        /// <summary>
        /// Average wait time before call is answered in seconds.
        /// Calculation: AVG(Start - RingTime) WHERE Disposition = ANSWERED
        /// </summary>
        public const string AvgWaitTime = "telephony_call_avg_wait_time";
        
        /// <summary>
        /// Maximum wait time before call is answered in seconds.
        /// Calculation: MAX(Start - RingTime) WHERE calls were answered
        /// </summary>
        public const string MaxWaitTime = "telephony_call_max_wait_time";
        
        /// <summary>
        /// Number of unique active channels used in the time period.
        /// Calculation: COUNT(DISTINCT Channel) or COUNT(DISTINCT LinkedId)
        /// </summary>
        public const string ActiveChannels = "telephony_call_active_channels";
    }
}