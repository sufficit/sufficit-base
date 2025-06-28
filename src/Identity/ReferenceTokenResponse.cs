using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Identity
{
    public class ReferenceTokenResponse
    {
        public ReferenceTokenRequest Request { get; set; } = default!;

        public string Key { get; set; } = default!;

        public string Token { get; set; } = default!;


    }
}
