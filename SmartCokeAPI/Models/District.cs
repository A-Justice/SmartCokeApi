using System;
using System.Collections.Generic;

namespace SmartCokeAPI.Models
{
    public partial class District
    {
        public int Id { get; set; }
        public string DistrictId { get; set; }
        public string RegionId { get; set; }
        public string DistrictName { get; set; }
        public string Status { get; set; }
        public string AddedBy { get; set; }
        public string AddedDate { get; set; }
        public string EditBy { get; set; }
        public string EditTime { get; set; }

        public District IdNavigation { get; set; }
        public District InverseIdNavigation { get; set; }
    }
}
