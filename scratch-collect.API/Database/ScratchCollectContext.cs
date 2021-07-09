using System;
using Microsoft.EntityFrameworkCore;

namespace scratch_collect.API.Database
{
    public class ScratchCollectContext : DbContext
    {
        public ScratchCollectContext(DbContextOptions<ScratchCollectContext> options) : base(options)
        {
        }

        // define db sets


        // custom db builder override
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // relations

            // custom seeds
        }
    }
}
