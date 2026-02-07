using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Identity.Configuration
{
    public class CookieOptions
    {
        public const string SECTIONNAME = "Sufficit:Identity:Cookie";

        public const string DEFAULT_AUTHENTICATION_TYPE = "Cookies";

        public const string DEFAULT_COOKIE_NAME = ".Sufficit.Identity.SufficitWeb";

        /// <summary>
        /// Titulo do provedor de autenticação por cookies, usado no momento de <br />
        /// AuthenticationManager.SignOut("My-AuthenticationType") <br />
        /// AuthenticationManager.SignIn("My-AuthenticationType") <br />
        /// 'Cookies' é o padrão utilizado quando não se específica nada no web.config
        /// </summary>
        public string AuthenticationType { get; set; } = DEFAULT_AUTHENTICATION_TYPE;

        public string Domain { get; set; } = ".sufficit.com.br";

        /// <summary>
        /// Cookie name
        /// </summary>
        public string Name { get; set; } = DEFAULT_COOKIE_NAME;

        public TimeSpan Expire { get; set; } = new TimeSpan(15, 0, 0, 0);

        public override bool Equals(object? other) =>
           other is CookieOptions p && (p.AuthenticationType, p.Domain, p.Name, p.Expire).Equals((AuthenticationType, Domain, Name, Expire));

        public override int GetHashCode() => (AuthenticationType, Domain, Name, Expire).GetHashCode();
    }
}
