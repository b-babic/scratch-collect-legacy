namespace scratch_collect.Model.Report
{
    public class SuccessOffersRequest
    {
        public string? TimeFrom { get; set; }
        public string? TimeTo { get; set; }
        public int? CategoryId { get; set; }
        public string? Category { get; set; }
    }
}