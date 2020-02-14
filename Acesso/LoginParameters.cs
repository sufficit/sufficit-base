using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Acesso
{
    public class LoginParameters
    {
        //[Required]
        public string UserName { get; set; }

        //[Required]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
