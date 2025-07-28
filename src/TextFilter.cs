using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit
{
    /// <summary>
    ///     Represents a text filter with exact match or contains functionality
    /// </summary>
    public class TextFilter : IEquatable<TextFilter>
    {
        #region Constructors

        /// <summary>
        ///     Default constructor required for JSON deserialization
        /// </summary>
        [JsonConstructor]
        public TextFilter()
        {
            Text = string.Empty;
        }

        /// <summary>
        ///     Creates a text filter with specified text
        /// </summary>
        /// <param name="text">The filter text</param>
        /// <param name="exactMatch">Whether to use exact match or contains</param>
        public TextFilter(string text, bool exactMatch = false)
        {
            Text = text ?? string.Empty;
            ExactMatch = exactMatch;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     The text to filter by
        /// </summary>
        [JsonPropertyName("text")]
        public string Text { get; set; }

        /// <summary>
        ///     Determines the filter behavior:
        ///     - true: Uses exact string matching (.Equals)
        ///     - false: Uses partial matching (.Contains)
        /// </summary>
        [JsonPropertyName("exactmatch")]
        public bool ExactMatch { get; set; }

        /// <summary>
        ///     Indicates whether the filter has any meaningful content
        /// </summary>
        [JsonIgnore]
        public bool IsEmpty => string.IsNullOrWhiteSpace(Text);

        /// <summary>
        ///     Indicates whether the filter is ready for use
        /// </summary>
        [JsonIgnore]
        public bool IsValid => !IsEmpty;

        #endregion

        #region Object Overrides

        public override string ToString()
            => Text ?? string.Empty;

        public override bool Equals(object? obj)
            => obj is TextFilter other && Equals(other);

        public bool Equals(TextFilter? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return string.Equals(Text, other.Text, StringComparison.Ordinal) &&
                   ExactMatch == other.ExactMatch;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 17;
                hash = hash * 23 + (Text?.GetHashCode() ?? 0);
                hash = hash * 23 + ExactMatch.GetHashCode();
                return hash;
            }
        }

        #endregion

        #region Operators

        public static bool operator ==(TextFilter? left, TextFilter? right)
            => Equals(left, right);

        public static bool operator !=(TextFilter? left, TextFilter? right)
            => !Equals(left, right);

        public static implicit operator string(TextFilter? filter)
            => filter?.Text ?? string.Empty;

        public static implicit operator TextFilter?(string? text)
            => string.IsNullOrWhiteSpace(text) ? null : new TextFilter(text);

        #endregion
    }
}
