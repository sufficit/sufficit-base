using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sufficit.Identity.Configuration
{
    /// <summary>
    /// (Sufficit) Opções de Autenticação OpenID
    /// </summary>
    public class OpenIDOptions
    {
        public OpenIDOptions()
        {
            Scopes = new SortedSet<string>();
        }

        public const string SECTIONNAME = "Sufficit:Identity:OpenID";

        public bool RequireHttpsMetadata { get; set; } = true;

        /// <summary>
        /// Titulo do provedor de autenticação por cookies, usado no momento de <br />
        /// AuthenticationManager.SignOut("My-AuthenticationType") <br />
        /// AuthenticationManager.SignIn("My-AuthenticationType") <br />
        /// 'oidc' é o padrão utilizado quando não se específica nada no web.config
        /// </summary>
        public string AuthenticationType { get; set; } = "oidc";
        public string Authority { get; set; } = "https://identity.sufficit.com.br";
        public string? Audience { get; set; }
        public string? ClientId { get; set; }
        public string? ClientSecret { get; set; }
        public string? ResponseType { get; set; }
        public string RedirectUri { get; set; } = "https://www.sufficit.com.br/oauth/authenticated";
        public bool SaveTokens { get; set; }
        public bool GetClaimsFromUserInfoEndpoint { get; set; } = true;

        public SortedSet<string> Scopes { get; }

        [Obsolete("Use Scopes instead !")]
        public string[] DefaultScopes => Scopes.ToArray();

        public string ScopesCommaSeparated => string.Join(",", Scopes);

        public override bool Equals(object? other) =>
           other is OpenIDOptions p && (p.RequireHttpsMetadata, p.AuthenticationType, p.Authority, p.Audience, p.ClientId, p.ClientSecret, p.ResponseType, p.RedirectUri, p.SaveTokens, p.GetClaimsFromUserInfoEndpoint, p.ScopesCommaSeparated)
            .Equals((RequireHttpsMetadata, AuthenticationType, Authority, Audience, ClientId, ClientSecret, ResponseType, RedirectUri, SaveTokens, GetClaimsFromUserInfoEndpoint, ScopesCommaSeparated));

        public override int GetHashCode() => (RequireHttpsMetadata, AuthenticationType, Authority, Audience, ClientId, ClientSecret, ResponseType, RedirectUri, SaveTokens, GetClaimsFromUserInfoEndpoint, ScopesCommaSeparated).GetHashCode();
    }
}
