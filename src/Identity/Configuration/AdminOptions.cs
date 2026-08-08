using Sufficit.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sufficit.Identity.Configuration
{
    /// <summary>
    /// (Sufficit) Opções de Autenticação OpenID
    /// </summary>
    public class AdminOptions : IHttpClientOptions
    {
        public const string SECTIONNAME = "Sufficit:Identity:Admin";

        public string BaseAddress { get; set; } 
            = "https://identityadmin.sufficit.com.br:26602";

        public string? BaseUrl { get => BaseAddress; set => BaseAddress = value ?? string.Empty; }

        public string? UserAgent { get; set; } = "C# Identity Admin API Client";

        /// <summary>
        /// Legacy Admin API scopes. The Skoruba Admin API was retired; this
        /// property remains only for source compatibility with older callers
        /// and no longer requests any scope by default.
        /// </summary>
        [Obsolete(
            "The legacy Skoruba Admin API was retired. Migrate to the Identity Management API and do not request its old scopes.",
            error: false)]
        public string[] Scopes { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Default TimeOut (seconds) for endpoints requests 
        /// </summary>
        public uint? TimeOut { get; set; }
    }
}
