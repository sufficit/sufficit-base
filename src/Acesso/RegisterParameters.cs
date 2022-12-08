using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sufficit.Acesso
{
    public class RegisterParameters
    {
        [Required]
        public string UserName { get; set; } = default!;

        [Required]
        public string Password { get; set; } = default!;

        [Required]
        [Compare(nameof(Password), ErrorMessage = "passwords do not match")]
        public string PasswordConfirm { get; set; } = default!;
    }
}
