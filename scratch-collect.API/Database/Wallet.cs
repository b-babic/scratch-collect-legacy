using System;
using System.ComponentModel.DataAnnotations;

namespace scratch_collect.API.Database
{
    public partial class Wallet
    {
        public int Id { get; set; }

        [Required]
        public double Balance { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        // Relations
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}