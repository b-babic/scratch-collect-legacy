using System;
using System.Collections.Generic;
using System.Text;

namespace scratch_collect.Model.Desktop
{
    public class OfferReportVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? PlayedOn { get; set; }

        public string Category { get; set; }

        public bool Won { get; set; }
    }
}