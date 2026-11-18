using System;
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

    public sealed class InterconnectionRegistrationTestResult
    {
        public string Node { get; set; } = string.Empty;
        public DateTimeOffset StartedAtUtc { get; set; }
        public InterconnectionRegistrationTestStatus Status { get; set; }
        public int? SipCode { get; set; }
        public int? ChallengeCode { get; set; }
        public InterconnectionRegistrationTestCleanup Cleanup { get; set; }
        public int? CleanupSipCode { get; set; }
    }
}
