using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiwiLoyalty.Models
{
    public class CustomerPointsEntry
    {
        public DateTime EntryDate { get; set; }
        public string EntryType { get; set; }
        public string PhoneNumber { get; set; }
        public float PointsAdded { get; set; }
        public float PointsRedeemed { get; set; }
    }
}
