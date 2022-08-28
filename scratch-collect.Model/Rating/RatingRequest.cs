using System;
using System.ComponentModel.DataAnnotations;

namespace scratch_collect.Model
{
    public class RatingRequest
    {
        [Required]
        public int OfferId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public double RateCount { get; set; }

        public DateTime? RatedOn { get; set; }
    }
}