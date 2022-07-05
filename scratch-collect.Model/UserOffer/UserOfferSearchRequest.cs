namespace scratch_collect.Model.Requests
{
    public class UsserOfferSearchRequest
    {
        public int UserId { get; set; }
        public int? CategoryId { get; set; }
        public bool? Played { get; set; }
        public string? Query { get; set; }

        // Time range filter
        public string? TimeFrom { get; set; }

        public string? TimeTo { get; set; }
    }
}