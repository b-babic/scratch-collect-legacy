using System.ComponentModel.DataAnnotations;

namespace scratch_collect.Model.Requests
{
    public class CouponUseRequest
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int WalletId { get; set; }

        [Required]
        public int CouponId { get; set; }
    }
}