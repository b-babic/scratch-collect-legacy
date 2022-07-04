using System;
using System.Collections.Generic;
using System.Text;

namespace scratch_collect.Desktop.Reports.Models
{
    public class TestVM
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Category { get; set; }

        public DateTime PlayedOn { get; set; }
        public bool Won { get; set; }
    }
}