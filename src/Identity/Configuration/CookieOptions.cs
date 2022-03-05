using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Identity.Configuration
{
    public class CookieOptions
    {
        public const string SECTIONNAME = "Sufficit:Identity:Cookie";

        /// <summary>
        /// Titulo do provedor de autenticação por cookies, usado no momento de <br />
        /// AuthenticationManager.SignOut("My-AuthenticationType") <br />
        /// AuthenticationManager.SignIn("My-AuthenticationType") <br />
        /// 'Cookies' é o padrão utilizado quando não se específica nada no web.config
        /// </summary>
        public string AuthenticationType { get; set; } = "Cookies";

        public string Domain { get; set; } = ".sufficit.com.br";

        /// <summary>
        /// Cookie name
        /// </summary>
        public string Name { get; set; } = ".Sufficit.Identity.SufficitWeb";

        public TimeSpan Expire { get; set; } = new TimeSpan(15, 0, 0, 0);

        public override bool Equals(object other) =>
           other is CookieOptions p && (p.AuthenticationType, p.Domain, p.Name, p.Expire).Equals((AuthenticationType, Domain, Name, Expire));

        public override int GetHashCode() => (AuthenticationType, Domain, Name, Expire).GetHashCode();
    }
}
