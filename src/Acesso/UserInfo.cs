using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Sufficit.Acesso
{
    public class UserInfo
    {
        public static readonly UserInfo Anonymous = new UserInfo();

        public bool IsAuthenticated { get; set; }
        public string UserName { get; set; }
        public Dictionary<string, string> ExposedClaims { get; set; }
        public string NameClaimType { get; set; }
        public string RoleClaimType { get; set; }
        public ICollection<ClaimValue> Claims { get; set; }
    }

    public class ClaimValue
    {
        public ClaimValue()
        {

        }

        public ClaimValue(string type, string value)
        {
            Type = type;
            Value = value;
        }

        public string Type { get; set; }

        public string Value { get; set; }
    }
}
