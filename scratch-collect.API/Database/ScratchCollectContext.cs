using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace scratch_collect.API.Database
{
    public partial class ScratchCollectContext : DbContext
    {
        public ScratchCollectContext()
        {
        }

        public ScratchCollectContext(DbContextOptions<ScratchCollectContext> options)
            : base(options)
        {
        }

        // define db sets
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Wallet> Wallets { get; set; }
        public virtual DbSet<UserOffer> UserOffers { get; set; }
        public virtual DbSet<Coupon> Coupons { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Merchant> Merchants { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;

            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Development.json")
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("collect"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            base.OnModelCreating(modelBuilder);

            // Relations

            // Users and roles
            modelBuilder.Entity<Role>(entity =>
            {
                entity
                    .HasMany(a => a.Users)
                    .WithOne(b => b.Role);
            });

            // Users and coupons
            // Users and wallets
            // Users and offers
            modelBuilder.Entity<User>(entity =>
            {
                entity
                    .HasMany(d => d.UsedCoupons)
                    .WithOne(p => p.UsedBy);

                entity
                    .HasOne(u => u.Wallet)
                    .WithOne(w => w.User)
                    .HasForeignKey<Wallet>(b => b.UserId);

                entity
                    .HasMany(o => o.BoughtOffers)
                    .WithOne(a => a.User);
            });

            modelBuilder.Entity<Coupon>(entity =>
            {
                entity
                    .Property(b => b.CreatedAt)
                    .HasDefaultValueSql("getdate()");
            });

            // Merchants and countries
            modelBuilder.Entity<Merchant>(entity =>
            {
                entity
                    .HasOne(a => a.Country)
                    .WithMany(b => b.Merchants)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            // Categories and offers
            modelBuilder.Entity<Category>(entity =>
            {
                entity
                    .HasMany(e => e.Offers)
                    .WithOne(e => e.Category);
            });

            // Offers and ratings
            modelBuilder.Entity<Rating>(entity =>
            {
                entity
                    .HasOne(r => r.Offer)
                    .WithMany(r => r.OfferRatings);
            });

            // custom partial for setting seed data
            OnModelCreatingPartial(modelBuilder);
        }

        private partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}