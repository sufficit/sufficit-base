using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit
{
    public class TextFilterWithKeys : TextFilter
    {        
        [JsonConstructor] // must be a public constructor
        public TextFilterWithKeys()
        {
            Text = default!;
        }        

        public TextFilterWithKeys (string text)
        {
            Text = text;
        }

        /// <summary>
        ///     Match text to these keys only, used to pre-filter results
        /// </summary>
        public HashSet<string>? Keys { get; set; }

        public static implicit operator string(TextFilterWithKeys filter)
            => filter.Text;

        public static implicit operator TextFilterWithKeys(string text)
            => new TextFilterWithKeys(text);

        public override bool Equals(object? obj)
            => obj is TextFilterWithKeys p && p.Text == Text && p.Keys == Keys && p.ExactMatch == ExactMatch;

        public override int GetHashCode()
            => (Text, Keys, ExactMatch).GetHashCode();
    }
}
