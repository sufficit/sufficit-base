using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit
{
    public class TextFilter
    {
        [JsonConstructor] // must be a public constructor
        public TextFilter()
        {
            Text = default!;
        }

        public TextFilter(string text)
        {
            Text = text;
        }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("exactmatch")]
        public bool ExactMatch { get; set; }

        public override string ToString()
            => Text;

        public static implicit operator string (TextFilter filter)
            => filter.Text;

        public static implicit operator TextFilter? (string? text)
            => string.IsNullOrWhiteSpace(text) ? null : new TextFilter(text!);

        public override bool Equals(object? obj)
            => obj is TextFilter p && p.Text == Text && p.ExactMatch == ExactMatch;

        public override int GetHashCode()
            => (Text, ExactMatch).GetHashCode();
    }
}
