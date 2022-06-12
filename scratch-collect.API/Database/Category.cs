using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace scratch_collect.API.Database
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Category name must have max 100 characters.")]
        public string Name { get; set; }

        // NOTE: Gradient start and stop colors represented by #hex value.
        [Required]
        [MaxLength(7, ErrorMessage = "Category gradient start color must have max 7 characters (including # sign).")]
        public string GradientStart { get; set; }

        [Required]
        [MaxLength(7, ErrorMessage = "Category gradient stop color must have max 7 characters (including # sign).")]
        public string GradientStop { get; set; }

        // Relations
        public virtual ICollection<Offer> Offers { get; set; }
    }
}