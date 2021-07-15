using System;
using System.Collections.Generic;

namespace scratch_collect.Model.Auth
{
    public class SignedUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
       
        public string Token { get; set; }
    }
}