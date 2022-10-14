using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit
{
    /// <summary>
    /// Always lower string not nullable
    /// </summary>
    public struct NormalizedString
    {
        public NormalizedString(string? s) => value = s?.Trim().ToLowerInvariant();

        public string ToLowerInvariant() => value ?? string.Empty;

        private readonly string? value;

        public static implicit operator NormalizedString(string? obj)
            => new NormalizedString(obj);

        public static implicit operator string(NormalizedString? obj)
            => obj?.value ?? string.Empty;

        public override string ToString()
            => value ?? string.Empty;

        public override bool Equals(object? obj)
            => obj?.ToString()?.Trim().ToLowerInvariant().Equals(value) ?? false;

        public override int GetHashCode()
            => value?.GetHashCode() ?? base.GetHashCode();

        public static bool operator ==(NormalizedString left, NormalizedString right)
            => left.Equals(right);

        public static bool operator !=(NormalizedString left, NormalizedString right)
            => !(left == right);
    }
}
