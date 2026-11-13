using System.Text.Json.Serialization;

namespace Sufficit.Finance
{
    /// <summary>Request to cancel a service invoice (NFS-e) at the fiscal provider.</summary>
    public class FiscalCancelRequest
    {
        /// <summary>Why the invoice is canceled (kept in the audit trail; the provider takes no reason).</summary>
        [JsonPropertyName("reason")]
        public string Reason { get; set; } = string.Empty;
    }
}
