﻿using System;
using System.Text;
using System.Text.Json.Serialization;
using static Sufficit.Constants;

namespace Sufficit
{
    /// <summary>
    ///     Ranged Date/Time Interval, prefer UTC
    /// </summary>
    /// <see cref="DateTimeRangeNew"/> should migrate soon to this property
    public class DateTimeRange
    {
        /// <summary>
        ///     Start date and time to filter
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("start")]
        [DateTimeKind(DateTimeKind.Utc)]
        public DateTime? Start { get; set; }

        /// <summary>
        ///     End, limit date and time to filter
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("end")]
        [DateTimeKind(DateTimeKind.Utc)]
        public DateTime? End { get; set; }

        /// <summary>
        ///     Use inclusive range, minor or grater and equals, or, just minor and grater comparisons
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("inclusive")]
        public bool Inclusive { get; set; }

        public override string ToString()
        {
            string result;
            if (Start.HasValue && End.HasValue)
                result = $"{Start.Value.ToString(DATETIMEFORMAT)} => {End.Value.ToString(DATETIMEFORMAT)}";
            else if (Start.HasValue)
                result = $"{Start.Value.ToString(DATETIMEFORMAT)} => ?";
            else if (End.HasValue)
                result = $"? => {End.Value.ToString(DATETIMEFORMAT)}";
            else
                result = "? => ?";

            if (Inclusive)
                result += ", *";

            return result;
        }
    }
}
