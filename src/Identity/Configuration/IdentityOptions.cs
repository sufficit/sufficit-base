using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Identity.Configuration
{
    public class IdentityOptions
    {
        public IdentityOptions()
        {
            Cookie = new CookieOptions();
            OpenID = new OpenIDOptions();
        }

        public const string SECTIONNAME = "Sufficit:Identity";

        public Uri ChangePasswordUri { get; set; } = new Uri("https://identity.sufficit.com.br/manage/changepassword");

        public CookieOptions Cookie { get; }

        public OpenIDOptions OpenID { get; }

        public override bool Equals(object other) =>
            other is IdentityOptions p && (p.ChangePasswordUri, p.Cookie, p.OpenID).Equals((ChangePasswordUri, Cookie, OpenID));

        public override int GetHashCode() => (ChangePasswordUri, Cookie, OpenID).GetHashCode();
    }
}
