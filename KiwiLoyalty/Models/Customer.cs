using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiwiLoyalty.Models
{
    class Customer
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string EntryReason { get; set; }
        public int? PointsBalance { get; set; }
        public int? PointsTotal { get; set; }
        public string EmailAddress { get; set; }
        public bool IsEmailAuthorized { get; set; }
    }
}
