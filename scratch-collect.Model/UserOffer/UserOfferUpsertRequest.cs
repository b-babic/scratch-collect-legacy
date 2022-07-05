namespace scratch_collect.Model
{
    public class UserOfferUpsertRequest
    {
        public int? Id { get; set; }

        public bool? Played { get; set; }

        // relations
        public int UserId { get; set; }

        public int OfferId { get; set; }
    }
}