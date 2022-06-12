using System;

namespace scratch_collect.Model
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public RoleDTO Role { get; set; }
        public WalletDTO Wallet { get; set; }

#nullable enable
        public DateTime? RegisteredAt { get; set; }
        public byte[]? UserPhoto { get; set; }
#nullable disable
    }
}