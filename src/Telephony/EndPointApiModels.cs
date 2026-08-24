using System;
using System.Text.Json;

namespace Sufficit.Telephony
{
    public sealed class ProvisioningEndPointResponse
    {
        public ProvisioningEndPointResponse(Guid id, string title, string? description, string password)
        {
            Id = id;
            Title = title;
            Description = description;
            Password = password;
        }

        public Guid Id { get; }

        public string Title { get; }

        public string? Description { get; }

        public string Password { get; }
    }

    public sealed class ChromeExtensionSilentCallReportRequest
    {
        public string? IssueType { get; set; }

        public string? Source { get; set; }

        public DateTimeOffset? ReportedAt { get; set; }

        public JsonElement Payload { get; set; }
    }

    public sealed class ChromeExtensionSilentCallReportResponse
    {
        public Guid IncidentId { get; set; }

        public DateTimeOffset ReceivedAt { get; set; }

        public Guid? EndPointId { get; set; }

        public string? Extension { get; set; }
    }

    public sealed class SavedTimeIntervalResult
    {
        public Guid Id { get; set; }

        public Guid ContextId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string FreePbx { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;
    }
}
