using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.CallForward
{
    /// <summary>
    /// Diagnostic result returned by the call-forward check endpoint.
    /// Contains the current persisted rule state, runtime registration status,
    /// and destination/callerid configuration resolved at check time.
    /// </summary>
    public sealed class CallForwardDiagnosticResult
    {
        /// <summary>The call-forward rule identifier used for this diagnostic check.</summary>
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        /// <summary>True when the rule exists in the persistent store.</summary>
        [JsonPropertyName("ruleFound")]
        public bool RuleFound { get; set; }

        /// <summary>Human-readable rule title, if found.</summary>
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        /// <summary>Human-readable rule description, if found.</summary>
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        /// <summary>True when the rule is present and active in the FastAGI runtime store.</summary>
        [JsonPropertyName("isInRuntime")]
        public bool IsInRuntime { get; set; }

        /// <summary>Resolved destination (E.164 or Asterisk dial string).</summary>
        [JsonPropertyName("destination")]
        public string? Destination { get; set; }

        /// <summary>
        /// True when Destination appears to be an external E.164 number.
        /// False when it looks like an internal Asterisk extension.
        /// </summary>
        [JsonPropertyName("isExternal")]
        public bool IsExternal { get; set; }

        /// <summary>Configured outbound CallerID number. Null means automatic.</summary>
        [JsonPropertyName("outboundCallerIdNumber")]
        public string? OutboundCallerIdNumber { get; set; }

        /// <summary>Maximum ring timeout in seconds.</summary>
        [JsonPropertyName("timeout")]
        public int Timeout { get; set; }

        /// <summary>Context identifier associated with the rule.</summary>
        [JsonPropertyName("contextId")]
        public Guid ContextId { get; set; }

        /// <summary>True when the rule exists, has a valid destination and is registered in runtime.</summary>
        [JsonPropertyName("isHealthy")]
        public bool IsHealthy => RuleFound && IsInRuntime && !string.IsNullOrWhiteSpace(Destination);

        /// <summary>Informational diagnostic notes collected during the check.</summary>
        [JsonPropertyName("notes")]
        public List<string> Notes { get; set; } = new();
    }
}
