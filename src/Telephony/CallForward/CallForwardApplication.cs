using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.CallForward
{
    /// <summary>
    /// Standalone proactive call forwarding application. <br />
    /// Routes an inbound call to a fixed internal or external destination.
    /// </summary>
    [DataContract]
    public class CallForwardApplication : IDestination, IFriendly, IIncrementalTracking
    {
        public const string ASTERISKCONTEXT = "sufficit-app-forward";
        public const string FRIENDLYNAME = "Encaminhamento de Chamada";

        #region IMPLEMENT INTERFACE IFRIENDLY

        string IFriendly.ToFriendly() => FRIENDLYNAME;

        #endregion
        #region IMPLEMENT INTERFACE IDESTINATION

        Guid? IDestination.Id => Id;

        string IDestination.TypeName => typeof(CallForwardApplication).Name;

        Guid? IDestination.ContextId => ContextId;

        string IDestination.Asterisk => $"{ASTERISKCONTEXT},{Id:N},1";

        string? IDestination.Title => Title;

        string? IDestination.Description => Description;

        #endregion

        /// <summary>
        /// Unique identifier for this call-forward rule.
        /// </summary>
        [DataMember(Name = "id", IsRequired = true, Order = 0)]
        [Column("id")]
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Context (tenant) that owns this rule.
        /// </summary>
        [DataMember(Name = "contextid", IsRequired = true, Order = 1)]
        [Column("contextid")]
        [JsonPropertyName("contextid")]
        public Guid ContextId { get; set; }

        /// <summary>
        /// Machine-friendly identifier used to locate this rule (e.g. "forward-suporte").
        /// </summary>
        [DataMember(Name = "title", IsRequired = true, Order = 2)]
        [Column("title"), StringLength(255), DefaultValue("")]
        [JsonPropertyName("title")]
        public string Title { get; set; } = default!;

        /// <summary>
        /// Human-readable label for this rule.
        /// </summary>
        [DataMember(Name = "description", IsRequired = false, Order = 3)]
        [Column("description"), StringLength(500), DefaultValue(null)]
        [JsonPropertyName("description")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Description { get; set; }

        /// <summary>
        /// Asterisk dial string for the forward target. <br />
        /// Internal: the <see cref="IDestination.Asterisk"/> of the target object. <br />
        /// External: E.164 phone number prefixed with <c>+</c> (e.g. <c>+5521967609095</c>).
        /// </summary>
        [DataMember(Name = "destination", IsRequired = true, Order = 4)]
        [Column("destination"), StringLength(250)]
        [JsonPropertyName("destination")]
        public string Destination { get; set; } = default!;

        /// <summary>
        /// Maximum ring duration in seconds before the call is considered unanswered.
        /// </summary>
        [DataMember(Name = "timeout", IsRequired = false, Order = 5)]
        [Column("timeout"), DefaultValue(30)]
        [JsonPropertyName("timeout")]
        public int Timeout { get; set; } = 30;

        /// <summary>
        /// When <c>true</c>, the outbound CallerID is replaced with the trunk's default number,
        /// hiding the original caller's identity.
        /// </summary>
        [DataMember(Name = "masked", IsRequired = false, Order = 6)]
        [Column("masked"), DefaultValue(false)]
        [JsonPropertyName("masked")]
        public bool Masked { get; set; }

        /// <summary>
        /// Logical last-change watermark used by incremental runtime refresh.
        /// </summary>
        [DataMember(Name = "timestamp", IsRequired = false, Order = 7)]
        [Column("timestamp")]
        [JsonPropertyName("timestamp")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Logical soft-delete marker. Null means the rule is active.
        /// </summary>
        [DataMember(Name = "deleted", IsRequired = false, Order = 8)]
        [Column("deleted")]
        [JsonPropertyName("deleted")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime? Deleted { get; set; }
    }
}
