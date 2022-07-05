using System.ComponentModel.DataAnnotations;

namespace scratch_collect.Model.Requests
{
    public class PaymentBuyRequest
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public string CardNumber { get; set; }

        [Required]
        public string ExpiryDate { get; set; }

        [Required]
        public string CVV { get; set; }

        [Required]
        public double Amount { get; set; }
    }
}