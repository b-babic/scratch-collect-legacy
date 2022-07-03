using System;
using System.Collections.Generic;

namespace scratch_collect.Model
{
    public class RatingDTO
    {
        public int Id { get; set; }

        public double RateCount { get; set; }

        public DateTime RatedOn { get; set; }

        // relations
        public UserDTO User { get; set; }

        public OfferDTO Offer { get; set; }
    }
}