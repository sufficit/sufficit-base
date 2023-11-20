using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Configuration
{
    /// <summary>
    ///     Partial (Configuration) constants deep class
    /// </summary>
    public struct Constants
    {
        /// <summary>
        /// Caminho utilizado após a autenticação no serviço de identidade
        /// </summary>
        public const string PostAuthenticatePath = "/acesso/autenticado.ashx";

        public const string OIDCAuthenticationType = "oidc";

        /// <summary>
        /// Método padrão de Authenticação, existe também o ApplicationCookie mas acho que é uma versão antigo do mesmo sistema, ainda estudando sobre isso
        /// </summary>
        public const string DefaultAuthenticationTypes = "Cookies";

        public const string DefaultCookieName = ".Sufficit.Identity.SufficitWeb";


        public const string AuthenticationOptionsAuthority = "https://identity.sufficit.com.br";

        public const string ChromeExtensionCookieToken = "Sufficit.ChromeExtensionToken";


#if DEBUG
        /// <summary>
        ///     Public web base address
        /// </summary>
        public const string DefaultHostUrl = "https://localhost:44300";

        public const string CookieAuthenticationDefaultDomain = "localhost";
#else
        /// <summary>
        ///     Public web base address
        /// </summary>
        public const string DefaultHostUrl = "https://www.sufficit.com.br";
        
        public const string CookieAuthenticationDefaultDomain = ".sufficit.com.br";
#endif
    }
}
