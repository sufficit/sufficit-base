using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit
{
    public class TextFilter
    {
        [JsonConstructor]
        public TextFilter()
        {
            Text = default!;
        }

        public TextFilter(string text)
        {
            Text = text;
        }   

        public string Text { get; set; }

        public bool ExactMatch { get; set; }

        public override string ToString()
            => Text;

        public static implicit operator string(TextFilter filter)
            => filter.Text;

        public static implicit operator TextFilter(string text)
            => new TextFilter(text);

        public override bool Equals(object obj)
            => obj is TextFilter p && p.Text == Text && p.ExactMatch == ExactMatch;

        public override int GetHashCode()
            => (Text, ExactMatch).GetHashCode();
    }
}
