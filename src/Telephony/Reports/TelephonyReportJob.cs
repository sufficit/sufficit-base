using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.Reports
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TelephonyReportJobStatus
    {
        Queued,
        Running,
        Completed,
        Failed,
        Canceled
    }

    public sealed class TelephonyReportJob
    {
        public Guid Id { get; set; }
        public TelephonyReportJobStatus Status { get; set; }
        public string? Error { get; set; }
    }
}
