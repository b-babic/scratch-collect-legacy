using System;

namespace scratch_collect.Model.Requests
{
    public class UserOfferPlayRequest
    {
        public int UserOfferId { get; set; }
        public int OfferId { get; set; }
        public bool Won { get; set; }
    }
}