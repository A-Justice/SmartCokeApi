using System;
using System.Collections.Generic;

namespace SmartCokeAPI.Models
{
    public partial class CustomOrders
    {
        public int Id { get; set; }
        public string OrderId { get; set; }
        public string ProductName { get; set; }
        public string Size { get; set; }
        public string Quantity { get; set; }
        public string Total { get; set; }
        public string Amount { get; set; }
        public DateTime? DateLogged { get; set; }
    }
}
