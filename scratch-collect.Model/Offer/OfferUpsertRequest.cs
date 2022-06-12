using System;
using System.ComponentModel.DataAnnotations;

namespace scratch_collect.Model.Requests
{
    public class OfferUpsertRequest
    {
        public int? Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Description { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int RequiredPrice { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Relations
        [Required]
        public int CategoryId { get; set; }
    }
}