namespace Sufficit.Statistics
{
    public static class MetricValueTypes
    {
        public const string Decimal = "decimal";
        public const string Integer = "integer";
        public const string Boolean = "boolean";
        public const string String = "string";
    }

    public static class MetricTags
    {
        public const string Type = "type";
        public const string Period = "period";

        public const string Category = "category";

        /// <summary>
        /// Context Id, client or customer or section Id
        /// </summary>
        public const string ContextId = "contextid";
        public const string Subtype = "subtype";
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
    /// Metric aggregation periods for statistics
    /// </summary>
    public static class MetricPeriods
    {
        public const string Minutely = "minutely";
        public const string Hourly = "hourly";
        public const string Daily = "daily";
        public const string Weekly = "weekly";
        public const string Monthly = "monthly";
        public const string Yearly = "yearly";
    }
}