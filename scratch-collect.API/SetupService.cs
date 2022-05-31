using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using scratch_collect.API.Database;
using System;

namespace scratch_collect.API
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using var appContext = scope.ServiceProvider.GetRequiredService<ScratchCollectContext>();

                try
                {
                    appContext.Database.Migrate();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("Error while doing initial DB migration: {0}", ex));
                }
            }

            return host;
        }
    }
}