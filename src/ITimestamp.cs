using System;
using System.Text.Json.Serialization;

/*
These are examples of how to implement the ITimestamp interface in entity classes, with proper JSON serialization attributes to control the output format and conditions.
The actual implementation of the ITimestamp interface should be done in each entity class that requires these timestamp
JsonProperties doesn't works on interfaces, so the attributes must be applied in the concrete classes that implement ITimestamp, following the same pattern as shown below:

[JsonPropertyName("xxxxx")]
[JsonIgnore(Condition = xxxxxxx)]
*/

namespace Sufficit
{
    /// <summary>
    ///     Canonical contract for persisted entities that expose one UTC timestamp
    ///     suitable for incremental synchronization windows.
    ///     The physical column name may vary per table and must stay mapped in EF.
    /// </summary>
    public interface ITimestamp
    {
        /// <summary>
        ///    UTC timestamp of the entity's creation, used as a stable reference for incremental synchronization.
        /// </summary>
        [JsonPropertyName("created_at_utc")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        DateTime CreatedAtUtc { get; }

        /// <summary>
        ///    UTC timestamp of the entity's last update, used for incremental synchronization.
        /// </summary>
        [JsonPropertyName("updated_at_utc")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        DateTime? UpdatedAtUtc { get; }

        /// <summary>
        ///    UTC timestamp of the entity's soft deletion, used for incremental synchronization.
        /// </summary>
        [JsonPropertyName("deleted_at_utc")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        DateTime? DeletedAtUtc { get; }
    }
}
