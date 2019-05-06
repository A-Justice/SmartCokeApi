using System;
using System.Collections.Generic;

namespace SmartCokeAPI.Models
{
    public partial class PackSizes
    {
            public int Id { get; set; }
            public string ProductId { get; set; }
            public string Size { get; set; }
            public string Quantity { get; set; }
            public string Amount { get; set; }
            public string Status { get; set; }
            public string SizeId { get; set; }
            public string Type { get; set; }
    }
}
