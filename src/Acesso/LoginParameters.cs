using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Acesso
{
    public class LoginParameters
    {
        //[Required]
        public string UserName { get; set; } = string.Empty;

        //[Required]
        public string Password { get; set; } = string.Empty;

        public bool RememberMe { get; set; }
    }
}
