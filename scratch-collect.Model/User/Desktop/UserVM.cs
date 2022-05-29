using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace scratch_collect.Model.User.Desktop
{
    public class UserVM
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime? RegisteredAt { get; set; }
        public byte[] UserPhoto { get; set; }

        public string UserRole { get; set; }
    }
}