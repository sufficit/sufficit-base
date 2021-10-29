using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Identity.Configuration
{
    public class IdentityOptions
    {
        public const string SectionName = "Sufficit:Identity";

        public CookieOptions Cookie { get; set; }

        public OpenIDOptions OpenID { get; set; }

        public override bool Equals(object obj)
        { 
            if (obj == null) return false;

            IdentityOptions other = obj as IdentityOptions;
            if (other != null)
            {
                return Cookie == other.Cookie && OpenID == other.OpenID;
            }
            else throw new ArgumentException($"Object is not a { GetType() }");
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
