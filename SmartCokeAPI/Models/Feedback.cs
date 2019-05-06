using System;
using System.Collections.Generic;

namespace SmartCokeAPI.Models
{
    public partial class Feedback
    {
        public int Id { get; set; }
        public string Rating { get; set; }
        public string Comment { get; set; }
        public string LoggedDate { get; set; }
        public string OrderId { get; set; }
    }
}
