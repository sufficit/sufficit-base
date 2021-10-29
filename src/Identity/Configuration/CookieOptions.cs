using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Identity.Configuration
{
    public class CookieOptions
    {
        public const string SectionName = "Sufficit:Identity:Cookie";

        public string Domain { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            CookieOptions other = obj as CookieOptions;
            if (other != null)
            {
                string left = Domain + Name;
                string right = other.Domain + other.Name;
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
