using System;
using System.Collections.Generic;

namespace SmartCokeAPI.Models
{
    public partial class PromoCodes
    {
        public int Id { get; set; }
        public string PromoId { get; set; }
        public string OrganisationName { get; set; }
        public string OrganisationContact { get; set; }
        public string OrganisationEmail { get; set; }
        public string Status { get; set; }
        public DateTime? DateEntered { get; set; }
        public string ProjectedOrders { get; set; }
        public string Duration { get; set; }
    }
}
