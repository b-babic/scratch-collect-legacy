using System;

namespace scratch_collect.Model
{
    public class PaymentDetailsDTO
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string PaymentIntentId { get; set; }
        public long PaymentAmount { get; set; }
        public string Currency { get; set; }
        public string InvoiceId { get; set; }
        public string PaymentMethodId { get; set; }
    }
}