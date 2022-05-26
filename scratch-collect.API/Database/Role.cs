using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace scratch_collect.API.Database
{
    public sealed partial class Role
    {
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Role name must have max 30 characters.")]
        public string Name { get; set; }

        [MaxLength(200, ErrorMessage = "Description must have max 30 characters.")]
        public string Description { get; set; }

        private ICollection<UserRole> UserRoles { get; set; }
    }
}