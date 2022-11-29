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
        public string UserName { get; set; } = default!;
        public Dictionary<string, string>? ExposedClaims { get; set; }
        public string NameClaimType { get; set; } = default!;
        public string RoleClaimType { get; set; } = default!;
        public ICollection<ClaimValue>? Claims { get; set; } = default!;
    }    
}
