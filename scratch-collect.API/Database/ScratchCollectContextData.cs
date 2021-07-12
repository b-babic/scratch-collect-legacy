using Microsoft.EntityFrameworkCore;

namespace scratch_collect.API.Database
{
    public partial class ScratchCollectContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            // seed database with initial data
            modelBuilder.Entity<User>().HasData(Helper.Json.LoadFromFile<User>
                  ("User.json"));
            
            modelBuilder.Entity<Role>().HasData(Helper.Json.LoadFromFile<Role>
                ("Role.json"));
            
            modelBuilder.Entity<UserRole>().HasData(Helper.Json.LoadFromFile<UserRole>
                ("UserRole.json"));
        }
    }
}
