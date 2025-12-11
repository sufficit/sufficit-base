using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Represents a SIP URI identifier with user, domain, and optional port
    /// </summary>
    /// <remarks>
    /// Supports formats:
    /// - "user" (user only)
    /// - "user@domain" (user and domain)
    /// - "user@domain:port" (full URI with port)
    /// </remarks>
    public class SipUri
    {
        /// <summary>
        /// User part of the SIP URI (required)
        /// </summary>
        [JsonPropertyName("user")]
        [JsonPropertyOrder(0)]
        public string User { get; set; } = string.Empty;

        /// <summary>
        /// Domain part of the SIP URI (optional)
        /// </summary>
        [JsonPropertyName("domain")]
        [JsonPropertyOrder(1)]
        public string? Domain { get; set; }

        /// <summary>
        /// Port part of the SIP URI (optional)
        /// </summary>
        [JsonPropertyName("port")]
        [JsonPropertyOrder(2)]
        public int? Port { get; set; }

        /// <summary>
        /// Creates an empty SipUri
        /// </summary>
        public SipUri()
        {
        }

        /// <summary>
        /// Creates a SipUri with user only
        /// </summary>
        public SipUri(string user)
        {
            User = user ?? string.Empty;
        }

        /// <summary>
        /// Creates a SipUri with user and domain
        /// </summary>
        public SipUri(string user, string? domain)
        {
            User = user ?? string.Empty;
            Domain = domain;
        }

        /// <summary>
        /// Creates a SipUri with user, domain, and port
        /// </summary>
        public SipUri(string user, string? domain, int? port)
        {
            User = user ?? string.Empty;
            Domain = domain;
            Port = port;
        }

        /// <summary>
        /// Parses a SIP URI string into components
        /// </summary>
        /// <param name="uri">URI in format "user", "user@domain", or "user@domain:port"</param>
        /// <returns>Parsed SipUri object</returns>
        public static SipUri Parse(string uri)
        {
            if (string.IsNullOrWhiteSpace(uri))
                return new SipUri();

            var result = new SipUri();

            // Check for domain separator
            var atIndex = uri.IndexOf('@');
            if (atIndex < 0)
            {
                // No domain, just user
                result.User = uri;
                return result;
            }

            // Extract user part
            result.User = uri.Substring(0, atIndex);

            // Extract domain and possibly port
            var domainPart = uri.Substring(atIndex + 1);
            var colonIndex = domainPart.IndexOf(':');
            
            if (colonIndex < 0)
            {
                // No port, just domain
                result.Domain = domainPart;
            }
            else
            {
                // Extract domain and port
                result.Domain = domainPart.Substring(0, colonIndex);
                var portString = domainPart.Substring(colonIndex + 1);
                
                if (int.TryParse(portString, out var port))
                    result.Port = port;
            }

            return result;
        }

        /// <summary>
        /// Converts SipUri to string representation
        /// </summary>
        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(Domain))
                return User;

            if (!Port.HasValue)
                return $"{User}@{Domain}";

            return $"{User}@{Domain}:{Port}";
        }

        /// <summary>
        /// Implicit conversion from string to SipUri
        /// </summary>
        public static implicit operator SipUri(string uri)
        {
            return Parse(uri);
        }

        /// <summary>
        /// Implicit conversion from SipUri to string
        /// </summary>
        public static implicit operator string(SipUri uri)
        {
            return uri?.ToString() ?? string.Empty;
        }

        /// <summary>
        /// Equality comparison
        /// </summary>
        public override bool Equals(object? obj)
        {
            if (obj is SipUri other)
                return User == other.User && Domain == other.Domain && Port == other.Port;
            
            if (obj is string str)
                return ToString() == str;

            return false;
        }

        /// <summary>
        /// Hash code generation
        /// </summary>
        public override int GetHashCode()
        {
#if NET6_0_OR_GREATER
            return HashCode.Combine(User, Domain, Port);
#else
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (User?.GetHashCode() ?? 0);
                hash = hash * 23 + (Domain?.GetHashCode() ?? 0);
                hash = hash * 23 + (Port?.GetHashCode() ?? 0);
                return hash;
            }
#endif
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        public static bool operator ==(SipUri? left, SipUri? right)
        {
            if (ReferenceEquals(left, right))
                return true;
            if (left is null || right is null)
                return false;
            return left.Equals(right);
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        public static bool operator !=(SipUri? left, SipUri? right)
        {
            return !(left == right);
        }
    }
}
