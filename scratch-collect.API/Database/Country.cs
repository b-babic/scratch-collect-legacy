using System.Collections.Generic;

namespace scratch_collect.API.Database
{
    public class Country
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        // relations
        public ICollection<Merchant> Merchants { get; set; }
    }
}