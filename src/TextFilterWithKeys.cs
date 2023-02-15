using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit
{
    public class TextFilterWithKeys : TextFilter
    {
        public TextFilterWithKeys(string text)
        {
            Text = text;
        }

        /// <summary>
        /// Attributes keys to match text filter <br />
        /// If not set, defaults will be used
        /// </summary>
        public HashSet<string>? Keys { get; set; }

        public static implicit operator string(TextFilterWithKeys filter)
            => filter.Text;

        public static implicit operator TextFilterWithKeys(string text)
            => new TextFilterWithKeys(text);

        public override bool Equals(object obj)
            => obj is TextFilterWithKeys p && p.Text == Text && p.Keys == Keys && p.ExactMatch == ExactMatch;

        public override int GetHashCode()
            => (Text, Keys, ExactMatch).GetHashCode();
    }
}
