using System;

namespace scratch_collect.API.Database
{
    public class Merchant
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Telephone { get; set; }

        public DateTime CreatedAt { get; set; }

        // Relations
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}