using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Sufficit.Telephony.Asterisk
{
    public class AsteriskDestination
    {
        public virtual string? Context { get; set; }
        public virtual string? Extension { get; set; }
        public virtual string Priority { get; set; } = default!;

        public override bool Equals(object? obj)
            => obj is AsteriskDestination other && other.Context == Context && other.Extension == Extension && other.Priority == Priority;

        public override int GetHashCode()
            => (Context, Extension, Priority).GetHashCode();

        public static implicit operator string (AsteriskDestination dst)
            => dst.ToString();

        public static implicit operator AsteriskDestination(string? dst)
            => new AsteriskDestination(dst);

        public override string ToString()
        {
            string result = Priority;
            if (!string.IsNullOrWhiteSpace(Extension)) { result = $"{Extension},{result}"; }
            if (!string.IsNullOrWhiteSpace(Context)) { result = $"{Context},{result}"; }
            return result;
        }

        public AsteriskDestination(string? asterisk) 
        {
            if (!string.IsNullOrWhiteSpace(asterisk))
            {
                var splitted = asterisk!.Split(',');
                if (splitted.Length == 3)
                {
                    Context = splitted[0];
                    Extension = splitted[1];
                    Priority = splitted[2];
                }
                else if (splitted.Length == 2)
                {
                    Extension = splitted[0];
                    Priority = splitted[1];
                }
                else
                {
                    Priority = splitted[0];
                }
            }
        }
    }
}
