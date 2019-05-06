using System;
using System.Collections.Generic;

namespace SmartCokeAPI.Models
{
    public partial class Packages
    {
        public int Id { get; set; }
        public int? PackageNumber { get; set; }
        public string PackageName { get; set; }
        public int? PackageAmount { get; set; }
        public string PackageDesc { get; set; }
        public string Status { get; set; }
        public string PackageText { get; set; }
        public string Volume { get; set; }
    }
}
