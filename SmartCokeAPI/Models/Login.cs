using System;
using System.Collections.Generic;

namespace SmartCokeAPI.Models
{
    public partial class Login
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Fname { get; set; }
        public string LastName { get; set; }
        public string Status { get; set; }
    }
}
