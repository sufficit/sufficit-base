namespace Sufficit.Statistics
{
    /// <summary>
    /// Metric categories for statistics
    /// </summary>
    public static class MetricCategories
    {
        public const string ExchangeMessages = "exchange_messages";
        public const string TelephonyCalls = "telephony_calls";
        public const string Notifications = "notifications";
        public const string Sales = "sales";
        public const string Gateway = "gateway";
    }

    /// <summary>
    /// Metric types for statistics
    /// </summary>
    public static class MetricTypes
    {
        public const string Count = "count";
        public const string Rate = "rate";
        public const string Average = "average";
        public const string Percentage = "percentage";
        public const string Duration = "duration";
        public const string Size = "size";
    }

    /// <summary>
    /// Aggregation periods for statistics
    /// </summary>
    public static class AggregationPeriods
    {
        public const string Hourly = "hourly";
        public const string Daily = "daily";
        public const string Weekly = "weekly";
        public const string Monthly = "monthly";
        public const string Yearly = "yearly";
    }

    /// <summary>
    /// Subtypes for exchange_messages category
    /// </summary>
    public static class ExchangeSubtypes
    {
        public const string WhatsApp = "whatsapp";
        public const string Telegram = "telegram";
        public const string Email = "email";
        public const string SMS = "sms";
        public const string Voice = "voice";
        public const string WebChat = "webchat";
        public const string All = "all";
        public const string Default = "default";
    }

    /// <summary>
    /// Subtypes for telephony_calls category
    /// </summary>
    public static class TelephonySubtypes
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
    /// Subtypes for sales category
    /// </summary>
    public static class SalesSubtypes
    {
        public const string Website = "website";
        public const string MobileApp = "mobile_app";
        public const string Store = "store";
        public const string Partner = "partner";
        public const string Direct = "direct";
        public const string All = "all";
        public const string Default = "default";
    }

    /// <summary>
    /// Subtypes for notifications category
    /// </summary>
    public static class NotificationSubtypes
    {
        public const string Email = "email";
        public const string SMS = "sms";
        public const string Push = "push";
        public const string InApp = "in_app";
        public const string System = "system";
        public const string All = "all";
        public const string Default = "default";
    }

    /// <summary>
    /// Subtypes for gateway category
    /// </summary>
    public static class GatewaySubtypes
    {
        public const string Payment = "payment";
        public const string SMS = "sms";
        public const string Email = "email";
        public const string Voice = "voice";
        public const string Integration = "integration";
        public const string All = "all";
        public const string Default = "default";
    }

    /// <summary>
    /// Common metric names for exchange messages
    /// </summary>
    public static class ExchangeMessageMetrics
    {
        public const string TotalCount = "total_count";
        public const string SuccessCount = "success_count";
        public const string ErrorCount = "error_count";
        public const string SuccessRate = "success_rate";
        public const string ErrorRate = "error_rate";
        public const string AvgProcessingTime = "avg_processing_time";
        public const string MaxProcessingTime = "max_processing_time";
        public const string MinProcessingTime = "min_processing_time";
        public const string TotalSize = "total_size";
        public const string AvgSize = "avg_size";
    }

    /// <summary>
    /// Common metric names for telephony calls
    /// </summary>
    public static class TelephonyCallMetrics
    {
        public const string TotalCalls = "total_calls";
        public const string AnsweredCalls = "answered_calls";
        public const string MissedCalls = "missed_calls";
        public const string AnswerRate = "answer_rate";
        public const string AvgCallDuration = "avg_call_duration";
        public const string TotalCallDuration = "total_call_duration";
        public const string AvgWaitTime = "avg_wait_time";
        public const string MaxWaitTime = "max_wait_time";
        public const string CallsPerHour = "calls_per_hour";
        public const string ActiveChannels = "active_channels";
    }

    /// <summary>
    /// Common metric names for sales
    /// </summary>
    public static class SalesMetrics
    {
        public const string TotalRevenue = "total_revenue";
        public const string TotalOrders = "total_orders";
        public const string AvgOrderValue = "avg_order_value";
        public const string ConversionRate = "conversion_rate";
        public const string NewCustomers = "new_customers";
        public const string ReturningCustomers = "returning_customers";
        public const string RefundRate = "refund_rate";
        public const string TotalRefunds = "total_refunds";
    }

    /// <summary>
    /// Common metric names for notifications
    /// </summary>
    public static class NotificationMetrics
    {
        public const string TotalSent = "total_sent";
        public const string TotalDelivered = "total_delivered";
        public const string TotalFailed = "total_failed";
        public const string DeliveryRate = "delivery_rate";
        public const string FailureRate = "failure_rate";
        public const string OpenRate = "open_rate";
        public const string ClickRate = "click_rate";
        public const string UnsubscribeRate = "unsubscribe_rate";
    }

    /// <summary>
    /// Common metric names for gateways
    /// </summary>
    public static class GatewayMetrics
    {
        public const string TotalRequests = "total_requests";
        public const string SuccessfulRequests = "successful_requests";
        public const string FailedRequests = "failed_requests";
        public const string SuccessRate = "success_rate";
        public const string AvgResponseTime = "avg_response_time";
        public const string MaxResponseTime = "max_response_time";
        public const string TimeoutCount = "timeout_count";
        public const string ErrorRate = "error_rate";
    }
}
