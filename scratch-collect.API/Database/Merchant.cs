using System;
using System.ComponentModel.DataAnnotations;

namespace scratch_collect.API.Database
{
    public class Merchant
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Merchant name must have max 30 characters.")]
        public string Name { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Merchant address must have max 30 characters.")]
        public string Address { get; set; }

        [Required]
        public string Telephone { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        // Relations
        [Required]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}