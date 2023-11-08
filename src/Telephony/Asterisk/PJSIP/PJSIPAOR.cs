using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.Asterisk.PJSIP
{
    public class PJSIPAOR
    {
        [JsonPropertyName("id")]
        public virtual string id { get; set; } = default!;

        /// <summary>
        ///     Permanent contacts assigned to AoR
        /// </summary>
        [JsonPropertyName("contact")]
        [Column("contact")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual string? contact { get; set; }

        /// <summary>
        ///     Default expiration time in seconds for contacts that are dynamically bound to an AoR
        /// </summary>
        [JsonPropertyName("default_expiration")]
        [Column("default_expiration")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual int? default_expiration { get; set; }

        /// <summary>
        ///     Allow subscriptions for the specified mailbox(es)
        /// </summary>
        [JsonPropertyName("mailboxes")]
        [Column("mailboxes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual string? mailboxes { get; set; }

        /// <summary>
        ///     The voicemail extension to send in the NOTIFY Message-Account header
        /// </summary>
        [JsonPropertyName("voicemail_extension")]
        [Column("voicemail_extension")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual string? voicemail_extension { get; set; }

        /// <summary>
        ///     Maximum time to keep an AoR
        /// </summary>
        [JsonPropertyName("maximum_expiration")]
        [Column("maximum_expiration")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual int? maximum_expiration { get; set; }

        /// <summary>
        ///     Maximum number of contacts that can bind to an AoR
        /// </summary>
        [JsonPropertyName("max_contacts")]
        [Column("max_contacts")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual uint? max_contacts { get; set; }

        /// <summary>
        ///     Minimum keep alive time for an AoR
        /// </summary>
        [JsonPropertyName("minimum_expiration")]
        [Column("minimum_expiration")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual int? minimum_expiration { get; set; }

        /// <summary>
        ///     Determines whether new contacts replace existing ones
        /// </summary>
        [JsonPropertyName("remove_existing")]
        [Column("remove_existing")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual string? remove_existing { get; set; }

        /// <summary>
        ///     Determines whether new contacts should replace unavailable ones
        /// </summary>
        [JsonPropertyName("remove_unavailable")]
        [Column("remove_unavailable")]
        [NotMapped]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual string? remove_unavailable { get; set; }

        /// <summary>
        ///     Interval at which to qualify an AoR. <br />
        ///     If 0 never qualify. <br />
        ///     Time in seconds
        /// </summary>
        [JsonPropertyName("qualify_frequency")]
        [Column("qualify_frequency")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [DefaultValue(0)]
        public virtual int? qualify_frequency { get; set; }

        /// <summary>
        ///     Timeout for qualify. <br />
        ///     If the contact doesn’t respond to the OPTIONS request before the timeout, the contact is marked unavailable. <br />
        ///     If 0 no timeout. <br />
        ///     Time in fractional seconds.
        /// </summary>
        [JsonPropertyName("qualify_timeout")]
        [Column("qualify_timeout")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [DefaultValue(3.0)]
        public virtual float? qualify_timeout { get; set; }

        /// <summary>
        ///     Authenticates a qualify challenge response if needed
        /// </summary>
        [JsonPropertyName("authenticate_qualify")]
        [Column("authenticate_qualify")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual string? authenticate_qualify { get; set; }

        /// <summary>
        ///     Outbound proxy used when sending OPTIONS request
        /// </summary>
        [JsonPropertyName("outbound_proxy")]
        [Column("outbound_proxy")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual string? outbound_proxy { get; set; }

        /// <summary>
        ///     Enables Path support for REGISTER requests and Route support for other requests
        /// </summary>
        [JsonPropertyName("support_path")]
        [Column("support_path")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual string? support_path { get; set; }
    }
}
