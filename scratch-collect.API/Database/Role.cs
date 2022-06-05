using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace scratch_collect.API.Database
{
    public partial class Role
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Role name must have max 30 characters.")]
        public string Name { get; set; }

        [MaxLength(200, ErrorMessage = "Description must have max 30 characters.")]
        public string Description { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}