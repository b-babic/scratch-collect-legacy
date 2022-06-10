using System;

namespace scratch_collect.Model.Desktop
{
    public class MerchantVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Telephone { get; set; }

        public DateTime CreatedAt { get; set; }

        // Relations
        public string Country { get; set; }
    }
}