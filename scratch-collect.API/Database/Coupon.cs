using System;
using System.ComponentModel.DataAnnotations;

namespace scratch_collect.API.Database
{
    public partial class Coupon
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(9, ErrorMessage = "Coupon generated code can be max 10 characters.")]
        public string Text { get; set; }

        [Required]
        public int Value { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        // Optional
        public DateTime? UsedAt { get; set; }

        // Relationship
        public int? UsedById { get; set; }

        public virtual User UsedBy { get; set; }
    }
}