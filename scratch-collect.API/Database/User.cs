using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace scratch_collect.API.Database
{
    public partial class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Username name can have max 20 characters.")]
        public string Username { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "First name can have max 20 characters.")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Last name can have max 20 characters.")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Address can have max 30 characters.")]
        public string Address { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Email can have max 100 characters.")]
        public string Email { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Salt can have max 50 characters.")]
        public string PasswordSalt { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = "Hash can have max 500 characters.")]
        public string PasswordHash { get; set; }

        public string Token { get; set; }

        public DateTime? RegisteredAt { get; set; }

        public byte[] UserPhoto { get; set; }

        // relationships

        // User roles
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

        // User wallet
        public int? WalletId { get; set; }
        public virtual Wallet Wallet { get; set; }

        // Users used coupons
        public ICollection<Coupon> UsedCoupons { get; set; }
    }
}