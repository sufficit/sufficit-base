using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sufficit.Identity.Configuration
{
    /// <summary>
    /// (Sufficit) Opções de Autenticação OpenID
    /// </summary>
    public class AdminOptions
    {
        public const string SECTIONNAME = "Sufficit:Identity:Admin";

        /// <summary>
        /// Used on HttpClient 
        /// </summary>
        public string ClientId { get; set; } = "SufficitIdentityAdmin";

        public string BaseUrl { get; set; } = "https://identity.sufficit.com.br:26602";

        public string[] Scopes { get; set; } = {
            "skoruba_identity_admin_api", // necessário para manipular as permissões de usuários
        };
    }
}
