using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace scratch_collect.Model.Auth
{
    public class SigninRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }
    }
}