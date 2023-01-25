using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit
{
    public class TextFilter
    {
        public TextFilter(string text)
        {
            Text = text;
        }   

        public string Text { get; set; }

        /// <summary>
        /// Attributes keys to match text filter <br />
        /// If not set, defaults will be used
        /// </summary>
        public HashSet<string>? Keys { get; set; }

        public bool ExactMatch { get; set; }

        public override string ToString()
            => Text;

        public static implicit operator string(TextFilter filter)
            => filter.Text;

        public static implicit operator TextFilter(string text)
            => new TextFilter(text);

        public override bool Equals(object obj)
            => obj is TextFilter p && p.Text == Text && p.Keys == Keys && p.ExactMatch == ExactMatch;

        public override int GetHashCode()
            => (Text, Keys, ExactMatch).GetHashCode();
    }
}
