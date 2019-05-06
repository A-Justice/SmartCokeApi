using System;
using System.Collections.Generic;

namespace SmartCokeAPI.Models
{
    public partial class Region
    {
        public int Id { get; set; }
        public string RegionId { get; set; }
        public string RegionName { get; set; }
        public string Status { get; set; }
    }
}
