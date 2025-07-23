using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.Call
{
    /// <summary>
    /// Contains extra calculated properties for telephony calls.
    /// All JSON property names should follow snake_case naming convention.
    /// </summary>
    public class TelephonyCallExtras
    {
        #region EXTRA - CALCULATED PROPERTIES

        /// <summary>
        /// Gets or sets the duration of the operation in seconds.
        /// </summary>
        [JsonPropertyName("duration")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? Duration { get; set; }

        /// <summary>
        /// Gets or sets the count of call detail records found for this call.
        /// </summary>
        [JsonPropertyName("records_count")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? RecordsCount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this call is billed.
        /// </summary>
        [JsonPropertyName("billed")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IsBilled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this call was answered by follow me.
        /// </summary>
        [JsonPropertyName("answered_by_follow_me")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IsAnsweredByFollowMe { get; set; }

        /// <summary>
        /// Gets or sets the web status representation of the call.
        /// </summary>
        [JsonPropertyName("status_for_web")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? StatusForWeb { get; set; }

        /// <summary>
        /// Gets or sets the trunk service information.
        /// </summary>
        [JsonPropertyName("trunk_service")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? TrunkService { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this call has user fields/tags.
        /// </summary>
        [JsonPropertyName("user_fields")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? HasUserFields { get; set; }

        /// <summary>
        /// Gets or sets the user fields/tags as a comma-separated string.
        /// </summary>
        [JsonPropertyName("user_fields_text")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? UserFields { get; set; }

        /// <summary>
        /// Gets or sets the call classification information.
        /// </summary>
        [JsonPropertyName("classification")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CallClassification? Classification { get; set; }

        /// <summary>
        /// Gets or sets the web representation of the call classification.
        /// </summary>
        [JsonPropertyName("classification_for_web")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ClassificationForWeb { get; set; }

        /// <summary>
        /// Gets or sets the CSS icon class for the call status.
        /// </summary>
        [JsonPropertyName("icon_class_for_status")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? IconClassForStatus { get; set; }

        /// <summary>
        /// Gets or sets the CSS icon class for the call direction classification.
        /// </summary>
        [JsonPropertyName("icon_class_for_direction")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? IconClassForDirection { get; set; }

        /// <summary>
        /// Gets or sets the CSS icon class for the call model classification.
        /// </summary>
        [JsonPropertyName("icon_class_for_model")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? IconClassForModel { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the destination has a custom title.
        /// </summary>
        [JsonPropertyName("custom_destination_title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? HasCustomDestinationTitle { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the origin has a custom title.
        /// </summary>
        [JsonPropertyName("custom_origin_title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? HasCustomOriginTitle { get; set; }

        /// <summary>
        /// Gets or sets information about what end the call took (Portuguese: "Que fim levou").
        /// </summary>
        [JsonPropertyName("call_end_result")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? CallEndResult { get; set; }

        /// <summary>
        /// Gets or sets information about what origin the call took (Portuguese: "Que origem levou").
        /// </summary>
        [JsonPropertyName("call_origin_result")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? CallOriginResult { get; set; }

        /// <summary>
        /// Gets or sets the indeterminate tooltip information (Portuguese: "Indeterminado tooltip").
        /// </summary>
        [JsonPropertyName("indeterminate_tooltip")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? IndeterminateTooltip { get; set; }

        /// <summary>
        /// Gets or sets the formatted origin for web display.
        /// </summary>
        [JsonPropertyName("format_origin_for_web")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? FormatOriginForWeb { get; set; }

        /// <summary>
        /// Gets or sets the formatted destination for web display.
        /// </summary>
        [JsonPropertyName("format_destination_for_web")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? FormatDestinationForWeb { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this call might be invalid.
        /// </summary>
        [JsonPropertyName("possible_invalid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IsPossibleInvalid { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this is an identified call.
        /// </summary>
        [JsonPropertyName("identified_call")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IsIdentifiedCall { get; set; }

        /// <summary>
        /// Gets or sets the context ID associated with this call.
        /// </summary>
        [JsonPropertyName("context_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Guid? ContextId { get; set; }

        /// <summary>
        /// Gets or sets the first billed unique ID.
        /// </summary>
        [JsonPropertyName("first_billed_unique_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? FirstBilledUniqueId { get; set; }

        /// <summary>
        /// Gets or sets the E164 formatted phone number.
        /// </summary>
        [JsonPropertyName("e164")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? E164 { get; set; }

        /// <summary>
        /// Gets or sets the extension title information.
        /// </summary>
        [JsonPropertyName("extension_title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ExtensionTitle { get; set; }

        /// <summary>
        /// Gets or sets the contact title information.
        /// </summary>
        [JsonPropertyName("contact_title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ContactTitle { get; set; }

        #endregion
    }
}
