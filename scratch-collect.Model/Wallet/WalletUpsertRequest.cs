using System;

namespace scratch_collect.Model.Requests
{
    public class WalletUpsertRequest
    {
        public int? Id { get; set; }

        public double Balance { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        // relations
        public int UserId { get; set; }

        public UserDTO User { get; set; }
    }
}