using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace scratch_collect.Model.User
{
    public class UserUpsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; }
        
        [Required(AllowEmptyStrings =false)]
        public string Username { get; set; }
        
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        [Required]
        public string Address { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }
        
        public DateTime? RegisteredAt { get; set; }
        
        public byte[] UserPhoto { get; set; }
        
        public bool IsUpdateByAdmin { get; set; } = false;
        
        public List<int> Roles { get; set; } = new List<int>();
    }
}