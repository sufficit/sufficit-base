using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Identity.Configuration
{
    public class OpenIDOptions
    {
        public const string SectionName = "Sufficit:Identity:OpenID";

        public string Authority { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string ResponseType { get; set; }
        public bool SaveTokens { get; set; }

        public string[] Scopes { get; set; }
        public string[] DefaultScopes => Scopes;

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            OpenIDOptions other = obj as OpenIDOptions;
            if (other != null)
            {
                string left = Authority + ClientId + ClientSecret + ResponseType + SaveTokens + string.Join(",", Scopes);
                string right = other.Authority + other.ClientId + other.ClientSecret + other.ResponseType + SaveTokens + string.Join(",", other.Scopes);
                return left == right;
            }
            else throw new ArgumentException($"Object is not a { GetType() }");
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
