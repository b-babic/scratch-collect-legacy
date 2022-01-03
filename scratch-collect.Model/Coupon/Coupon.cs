using System;

namespace scratch_collect.Model.Coupon
{
    public class CouponModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
        public DateTime CreatedAt { get; set; }

        // used by and used at relationship ?
    }
}
