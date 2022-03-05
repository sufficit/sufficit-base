using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Identity
{
    public static class ClaimTypes
    {
        public const string MicrosoftNameIdentifier = System.Security.Claims.ClaimTypes.NameIdentifier;
        public const string MicrosoftRole = System.Security.Claims.ClaimTypes.Role;
        public const string Role = "role";
        public const string Directive = "directive";
    }
}
