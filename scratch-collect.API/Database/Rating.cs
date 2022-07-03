using System;
using System.ComponentModel.DataAnnotations;

namespace scratch_collect.API.Database
{
    public class Rating
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Range(1.0, 5.0, ErrorMessage = "Rating must be between 1 and 5")]
        public double RateCount { get; set; }

        [Required]
        public DateTime RatedOn { get; set; }

        // relations
        [Required]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        public int OfferId { get; set; }

        public virtual Offer Offer { get; set; }
    }
}