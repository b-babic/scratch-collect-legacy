using System;
using scratch_collect.API.Database;

namespace scratch_collect.API
{
    public class SetupService
    {
        public static void Init(ScratchCollectContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
