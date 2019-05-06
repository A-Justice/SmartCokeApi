using System;
using System.Collections.Generic;

namespace SmartCokeAPI.Models
{
    public partial class PackageBreakdown
    {
        public int Id { get; set; }
        public string PackageName { get; set; }
        public string ProductName { get; set; }
        public string PackSize { get; set; }
        public string Quantity { get; set; }
        public string Total { get; set; }
        public string AddedBy { get; set; }
        public string AddedDate { get; set; }
    }
}
