using System;

namespace scratch_collect.Model
{
    public class UserOfferDTO
    {
        public int Id { get; set; }

        public bool Played { get; set; }

        public DateTime BoughtOn { get; set; }

        // relations
        public int UserId { get; set; }
        public UserDTO User { get; set; }

        public int OfferId { get; set; }
        public OfferDTO Offer { get; set; }
    }
}