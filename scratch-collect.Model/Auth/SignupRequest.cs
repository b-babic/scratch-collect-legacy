using System;
using System.ComponentModel.DataAnnotations;

namespace scratch_collect.Model.Requests
{
    public class SignupRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Username { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string PasswordConfirm { get; set; }

        public DateTime? RegisteredAt { get; set; }

        public byte[] UserPhoto { get; set; }
    }
}