using System;

namespace scratch_collect.Model
{
    public class CouponDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime? UsedAt { get; set; }
    }
}