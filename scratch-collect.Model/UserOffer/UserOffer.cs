using System;

namespace scratch_collect.Model
{
    public class UserOfferDTO
    {
        public int Id { get; set; }
        public DateTime BoughtOn { get; set; }

        public bool Played { get; set; }
        public DateTime? PlayedOn { get; set; }

        public bool Won { get; set; }

        public double? AverageRating { get; set; } = 0.0;

        public bool AlreadyRated { get; set; }

        // relations
        public int UserId { get; set; }

        public UserDTO User { get; set; }

        public int OfferId { get; set; }
        public OfferDTO Offer { get; set; }
    }
}