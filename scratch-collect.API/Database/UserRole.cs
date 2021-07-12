using System;

namespace scratch_collect.API.Database
{
    public partial class UserRole
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        
        public DateTime UpdatedAt { get; set; }
        
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}