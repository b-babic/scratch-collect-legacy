using System;

namespace scratch_collect.Model.User.Desktop
{
    public class UserCreateVM
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime? RegisteredAt { get; set; }
        public byte[]? UserPhoto { get; set; }
    }
}