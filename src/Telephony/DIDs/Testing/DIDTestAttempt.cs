using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.DIDs.Testing
{
    /// <summary>Bounded AMI observations of one request, never a conclusion about DID arrival.</summary>
    public class DIDTestAttempt
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("runid")]
        public Guid RunId { get; set; }

        [JsonPropertyName("attempt")]
        public int Attempt { get; set; }

        [JsonPropertyName("originid")]
        public Guid OriginId { get; set; }

        [JsonPropertyName("originnumber")]
        public string OriginNumber { get; set; } = string.Empty;

        [JsonPropertyName("trunk")]
        public string Trunk { get; set; } = string.Empty;

        [JsonPropertyName("prefix")]
        public string Prefix { get; set; } = string.Empty;

        [JsonPropertyName("startedatutc")]
        public DateTime StartedAtUtc { get; set; }

        [JsonPropertyName("expiresatutc")]
        public DateTime ExpiresAtUtc { get; set; }

        [JsonPropertyName("acceptedatutc")]
        public DateTime? AcceptedAtUtc { get; set; }

        [JsonPropertyName("dialedatutc")]
        public DateTime? DialedAtUtc { get; set; }

        [JsonPropertyName("dialendedatutc")]
        public DateTime? DialEndedAtUtc { get; set; }

        [JsonPropertyName("originaterespondedatutc")]
        public DateTime? OriginateRespondedAtUtc { get; set; }

        [JsonPropertyName("finishedatutc")]
        public DateTime? FinishedAtUtc { get; set; }

        [JsonPropertyName("accepted")]
        public bool? Accepted { get; set; }

        [JsonPropertyName("originateresponse")]
        public string? OriginateResponse { get; set; }

        [JsonPropertyName("originatereason")]
        public int? OriginateReason { get; set; }

        [JsonPropertyName("dialstatus")]
        public string? DialStatus { get; set; }

        [JsonPropertyName("hangupcause")]
        public int? HangupCause { get; set; }

        [JsonPropertyName("sipcode")]
        public int? SipCode { get; set; }

        [JsonPropertyName("channel")]
        public string? Channel { get; set; }

        [JsonPropertyName("observationstatus")]
        public string ObservationStatus { get; set; } = "starting";

    }
}
