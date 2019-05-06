using System;
using System.Collections.Generic;

namespace SmartCokeAPI.Models
{
    public partial class Comolaints
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Date { get; set; }
        public string Status { get; set; }
    }
}
