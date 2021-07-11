using System;
using System.Collections.Generic;

namespace scratch_collect.Model.User
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
        public DateTime? RegisteredAt { get; set; }
        public byte[] UserPhoto { get; set; }
        
        public ICollection<UserRole.UserRole> UserRoles { get; set; }
    }
}