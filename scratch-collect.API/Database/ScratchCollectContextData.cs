using Microsoft.EntityFrameworkCore;

namespace scratch_collect.API.Database
{
    public partial class ScratchCollectContext
    {
        private partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            // seed database with initial data
            modelBuilder.Entity<User>().HasData(Helper.Json.LoadFromFile<User>
                  ("User.json"));

            modelBuilder.Entity<Role>().HasData(Helper.Json.LoadFromFile<Role>
                ("Role.json"));
            
            modelBuilder.Entity<Wallet>().HasData(Helper.Json.LoadFromFile<Wallet>
                ("Wallet.json"));

            modelBuilder.Entity<UserOffer>().HasData(Helper.Json.LoadFromFile<UserOffer>
                ("UserOffer.json"));

            modelBuilder.Entity<Coupon>().HasData(Helper.Json.LoadFromFile<Coupon>
                ("Coupon.json"));

            modelBuilder.Entity<Merchant>().HasData(Helper.Json.LoadFromFile<Merchant>
                ("Merchant.json"));

            modelBuilder.Entity<Country>().HasData(Helper.Json.LoadFromFile<Country>
                ("Country.json"));

            modelBuilder.Entity<Offer>().HasData(Helper.Json.LoadFromFile<Offer>
                ("Offer.json"));

            modelBuilder.Entity<Category>().HasData(Helper.Json.LoadFromFile<Category>
                ("Category.json"));
        }
    }
}