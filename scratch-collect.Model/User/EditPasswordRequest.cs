using System;
using System.ComponentModel.DataAnnotations;

namespace scratch_collect.Model.Requests
{
    public class EditPasswordRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string OldPassword { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string NewPassword { get; set; }
    }
}