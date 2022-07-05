using System;
using System.Collections.Generic;
using System.Text;

namespace scratch_collect.Model.Report
{
    public class SuccessOfferParam
    {
        public int? CategoryId { get; set; }
        public string? TimeFrom { get; set; }
        public string? TimeTo { get; set; }

        private SuccessOfferParam(int? categoryId, string timeFrom, string timeTo)
        {
            CategoryId = categoryId;
            TimeFrom = timeFrom;
            TimeTo = timeTo;
        }
    }
}