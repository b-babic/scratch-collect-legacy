using System;
using System.Collections.Generic;

namespace scratch_collect.Model
{
    public class OfferDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public int RequiredPrice { get; set; }

        public double AverageRating { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        // Relationship
        public CategoryDTO Category { get; set; }

        public ICollection<OfferDTO> RecommendedItems { get; set; }

        // Override string representation
        public override string ToString()
        {
            return Title;
        }
    }
}