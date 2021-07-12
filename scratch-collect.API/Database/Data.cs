using Microsoft.EntityFrameworkCore;

namespace scratch_collect.API.Database
{
    public static class Data
    {
        public static void Seed(ScratchCollectContext context)
        {
            context.Database.Migrate();
        }
    }
}