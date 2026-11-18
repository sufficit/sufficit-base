using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.InterConnection
{
    public sealed class InterconnectionRegistrationTestRequest
    {
        public Guid ContextId { get; set; }
        public Guid InterconnectionId { get; set; }
        public string Node { get; set; } = string.Empty;
        public string Host { get; set; } = string.Empty;
        public int Port { get; set; }
        public string Transport { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public sealed class InterconnectionRegistrationTestTarget
    {
        public string Node { get; set; } = string.Empty;
        public string Host { get; set; } = string.Empty;
        public int Port { get; set; }
        public string Transport { get; set; } = string.Empty;
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum InterconnectionRegistrationTestStatus
    {
        CommunicationFailure,
        Registered,
        AuthenticationChallenge,
        CredentialsRejected,
        RegistrarRejected,
        ContactNotConfirmed,
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum InterconnectionRegistrationTestCleanup
    {
        Unconfirmed,
        NotRequired,
        Confirmed,
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum InterconnectionRegistrationTestPhase
    {
        NodeConnection,
        Probe,
        Registration,
        Cleanup,
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum InterconnectionRegistrationTestEventKind
    {
        Connecting,
        Connected,
        RequestSent,
        AuthenticatedRequestSent,
        AuthenticationChallenge,
        AuthenticationIncomplete,
        Registered,
        CredentialsRejected,
        RegistrarRejected,
        ContactNotConfirmed,
        TimedOut,
        CommunicationFailure,
        Confirmed,
        Unconfirmed,
        NotRequired,
    }

    public sealed class InterconnectionRegistrationTestEvent
    {
        public DateTimeOffset TimestampUtc { get; set; }
        public InterconnectionRegistrationTestPhase Phase { get; set; }
        public InterconnectionRegistrationTestEventKind Kind { get; set; }
        public int? SipCode { get; set; }
    }

    public sealed class InterconnectionRegistrationTestResult
    {
        public string Node { get; set; } = string.Empty;
        public DateTimeOffset StartedAtUtc { get; set; }
        public InterconnectionRegistrationTestStatus Status { get; set; }
        public int? SipCode { get; set; }
        public int? ChallengeCode { get; set; }
        public InterconnectionRegistrationTestCleanup Cleanup { get; set; }
        public int? CleanupSipCode { get; set; }
        public List<InterconnectionRegistrationTestEvent> History { get; set; } = new List<InterconnectionRegistrationTestEvent>();
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum InterconnectionRegistrationTestJobStatus
    {
        Running,
        Completed,
        Interrupted,
    }

    public sealed class InterconnectionRegistrationTestJob
    {
        public Guid Id { get; set; }
        public Guid ContextId { get; set; }
        public DateTimeOffset CreatedAtUtc { get; set; }
        public DateTimeOffset ExpiresAtUtc { get; set; }
        public int Revision { get; set; }
        public InterconnectionRegistrationTestJobStatus Status { get; set; }
        public List<InterconnectionRegistrationTestEvent> History { get; set; } = new List<InterconnectionRegistrationTestEvent>();
        public InterconnectionRegistrationTestResult? Result { get; set; }
    }
}
