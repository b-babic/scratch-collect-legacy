using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace scratch_collect.API.Database
{
    public partial class Offer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Offer title can be max 100 characters!")]
        public string Title { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Offer title can be max 100 characters!")]
        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int RequiredPrice { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
         
        [Required]
        public DateTime UpdatedAt { get; set; }

        // Relationship
        [Required]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}