using System;
using System.ComponentModel.DataAnnotations;

namespace scratch_collect.Model.Requests
{
    public class EditProfileRequest
    {
        public string Email { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

    }
}