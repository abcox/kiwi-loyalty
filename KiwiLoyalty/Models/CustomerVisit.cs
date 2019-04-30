
using System;

namespace KiwiLoyalty.Models
{
    public class CustomerVisit
    {
        //public int pointsEntryKey { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public double Plus { get; set; }
        public double Minus { get; set; }
        public string Notes { get; set; }
    }
}