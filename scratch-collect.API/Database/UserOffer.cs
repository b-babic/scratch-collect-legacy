using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace scratch_collect.API.Database
{
    public partial class UserOffer
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public bool Played { get; set;}

        [Required]
        public DateTime BoughtOn { get; set; }

        // relations
        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set;}

        [Required]
        public int OfferId { get; set; }
        public virtual Offer Offer { get; set;}
    }
}