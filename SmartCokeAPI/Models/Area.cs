using System;
using System.Collections.Generic;

namespace SmartCokeAPI.Models
{
    public partial class Area
    {
        public int Id { get; set; }
        public string DistrictId { get; set; }
        public string RegionId { get; set; }
        public string AreaId { get; set; }
        public string AreaName { get; set; }
        public string Status { get; set; }
        public string ServCharge { get; set; }
        public string AddedBy { get; set; }
        public string AddedTime { get; set; }
        public string ChargeType { get; set; }
    }
}
