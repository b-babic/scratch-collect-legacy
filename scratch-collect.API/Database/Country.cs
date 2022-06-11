using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace scratch_collect.API.Database
{
    public class Country
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Country name must have max 100 characters.")]
        public string Name { get; set; }

        [Required]
        [MaxLength(5, ErrorMessage = "Country code must have max 5 characters.")]
        public string Code { get; set; }

        // relations
        public ICollection<Merchant> Merchants { get; set; }
    }
}