using System;

namespace scratch_collect.Model.UserRole
{
    public class UserRole
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual User.User User { get; set; }
        public virtual Role.Role Role { get; set; }

        public override string ToString()
        {
            return Role.ToString();
        }
    }
}