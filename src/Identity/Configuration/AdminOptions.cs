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

        public string[] Scopes { get; set; } = {
            "skoruba_identity_admin_api", // necessário para manipular as permissões de usuários
        };

        /// <summary>
        /// Default TimeOut (seconds) for endpoints requests 
        /// </summary>
        public uint? TimeOut { get; set; }
    }
}
