namespace Sufficit.Exchange
{
    /// <summary>
    /// Constants for exchange metrics names used in statistics collection
    /// </summary>
    public static class ExchangeMetrics
    {
        public const string Category = "exchange";
        public const string TotalMessages = Category + "_total_messages";
        public const string SuccessMessages = Category + "_success_messages";
        public const string ErrorMessages = Category + "_error_messages";
        public const string SuccessRate = Category + "_success_rate";
        public const string ActiveChannels = Category + "_active_channels";
    }

    public static class ExchangeMetricTags
    {
        public const string Channel = "channel";
    }

    
    /// <summary>
    /// Subtypes for exchange_messages category
    /// </summary>
    public static class ExchangeMetricSubtypes
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
}
