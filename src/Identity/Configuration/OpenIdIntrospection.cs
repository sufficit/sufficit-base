using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Identity.Configuration
{
    public class OpenIdIntrospection
    {
        public const string AuthenticationType = "introspection";
        public string? ResourceId { get; set; }
        public string? ResourceSecret { get; set; }
    }
}
