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
        /// <summary>
        /// Counter metric - incremental value that only goes up (e.g., total requests, errors)
        /// </summary>
        public const string Count = "count";
        
        /// <summary>
        /// Rate metric - frequency of events per unit of time (e.g., requests per second)
        /// </summary>
        public const string Rate = "rate";
        
        /// <summary>
        /// Average metric - mean value over time (e.g., average response time)
        /// </summary>
        public const string Average = "average";
        
        /// <summary>
        /// Percentage metric - value expressed as percentage 0-100% (e.g., success rate, CPU usage)
        /// </summary>
        public const string Percentage = "percentage";
        
        /// <summary>
        /// Duration metric - time measurements (e.g., response time, processing duration)
        /// </summary>
        public const string Duration = "duration";
        
        /// <summary>
        /// Size metric - measurements of quantity/volume (e.g., file size, memory usage)
        /// </summary>
        public const string Size = "size";
        
        /// <summary>
        /// Histogram metric - distribution of values across buckets (e.g., response time distribution)
        /// </summary>
        public const string Histogram = "histogram";
        
        /// <summary>
        /// Gauge metric - snapshot value at point in time that can go up/down (e.g., active sessions, queue size)
        /// </summary>
        public const string Gauge = "gauge";
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