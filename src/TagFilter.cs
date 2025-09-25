using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Sufficit
{
    /// <summary>
    /// Tag matching modes for flexible tag filtering
    /// </summary>
    public enum TagMode
    {
        /// <summary>
        /// Exact match of the tag
        /// </summary>
        Exact,

        /// <summary>
        /// Match by prefix (tag starts with the filter)
        /// </summary>
        Prefix,

        /// <summary>
        /// Match if contains the string
        /// </summary>
        Contains
    }

    /// <summary>
    /// Parameters for tag-based filtering of storage objects
    /// </summary>
    public class TagFilter : IEquatable<TagFilter>
    {
        /// <summary>
        /// Collection of tags or prefixes to filter by.
        /// If null or empty, filters for objects that have no tags.
        /// </summary>
        [JsonPropertyName("values")]
        public ICollection<NormalizedString>? Values { get; set; }

        /// <summary>
        /// Tag matching mode
        /// </summary>
        [JsonPropertyName("mode")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TagMode Mode { get; set; } = TagMode.Exact;

        /// <summary>
        /// If true, requires ALL tags to match (AND logic)
        /// If false, requires ANY tag to match (OR logic)
        /// </summary>
        [JsonPropertyName("matchall")]
        public bool MatchAll { get; set; } = true;

        #region Implicits

        /// <summary>
        /// Implicit conversion from string to TagFilter.
        /// Parses comma, pipe, colon, or semicolon separated tags.
        /// </summary>
        /// <param name="text">Text containing tags separated by , | : ;</param>
        public static implicit operator TagFilter(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return new TagFilter { Values = null }; // Filter for objects with no tags

            // Split by common separators: comma, pipe, semicolon, empty space
            var separators = new[] { ',', '|', ';', ' ' };
#if NET6_0_OR_GREATER
            var tags = text.Split(separators, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                          .Where(t => !string.IsNullOrWhiteSpace(t))
                          .Select(t => (NormalizedString)t)
                          .ToHashSet();
#else
            var tags = new HashSet<NormalizedString>();
            foreach (var tag in text.Split(separators, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(t => t.Trim())
                                   .Where(t => !string.IsNullOrWhiteSpace(t)))
            {
                tags.Add((NormalizedString)tag);
            }
#endif

            return new TagFilter
            {
                Values = tags.Count > 0 ? tags : null,
                Mode = TagMode.Exact,
                MatchAll = true
            };
        }

        #endregion
        #region Equality and Comparison

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        public override bool Equals(object? obj)
        {
            return Equals(obj as TagFilter);
        }

        /// <summary>
        /// Determines whether the specified TagFilter is equal to the current TagFilter.
        /// </summary>
        public bool Equals(TagFilter? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            // Compare mode and matchall first (fast comparison)
            if (Mode != other.Mode || MatchAll != other.MatchAll) return false;

            // Compare values directly (already normalized)
            if (Values is null && other.Values is null) return true;
            if (Values is null || other.Values is null) return false;

            if (Values.Count != other.Values.Count) return false;

            // Values are already NormalizedString, so we can compare directly
            return Values.OrderBy(v => v.ToString()).SequenceEqual(other.Values.OrderBy(v => v.ToString()));
        }

        /// <summary>
        /// Returns a hash code for this TagFilter.
        /// </summary>
        public override int GetHashCode()
        {
#if NET6_0_OR_GREATER
            var hash = HashCode.Combine(Mode, MatchAll);
#else
            var hash = Mode.GetHashCode() ^ MatchAll.GetHashCode();
#endif

            if (Values != null)
            {
                // Values are already NormalizedString, so we can use them directly
                // Create a single hash from all ordered normalized tags
                var orderedTags = Values.OrderBy(v => v.ToString()).ToArray();
                var combinedTagString = string.Join("|", orderedTags.Select(t => t.ToString()));

#if NET6_0_OR_GREATER
                hash = HashCode.Combine(hash, combinedTagString.GetHashCode());
#else
                hash = hash ^ combinedTagString.GetHashCode();
#endif
            }

            return hash;
        }

        #endregion
    }
}