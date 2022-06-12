using System;
using System.ComponentModel.DataAnnotations;

namespace scratch_collect.Model.Requests
{
    public class UserUpsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Username { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Address { get; set; }

        [Required]
        public int RoleId { get; set; }

        [Required]
        public int WalletId { get; set; }

#nullable enable
        public string? Password { get; set; }

        public DateTime? RegisteredAt { get; set; }

        public byte[]? UserPhoto { get; set; }
#nullable disable
    }
}