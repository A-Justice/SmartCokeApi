using System;
using System.Collections.Generic;

namespace SmartCokeAPI.Models
{
    public partial class CustomProducts
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string PackSize { get; set; }
        public string UnitAmount { get; set; }
        public string Status { get; set; }
        public string ProductId { get; set; }
        public string AddedBy { get; set; }
        public string AddedDate { get; set; }
    }
}
