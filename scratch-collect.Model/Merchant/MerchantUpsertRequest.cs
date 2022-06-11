using System;
using System.ComponentModel.DataAnnotations;

namespace scratch_collect.Model
{
    public class MerchantUpsertRequest
    {
        public int? Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Address { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Telephone { get; set; }

        public DateTime? CreatedAt { get; set; }

        // Relations
        [Required]
        public int CountryId { get; set; }
    }
}