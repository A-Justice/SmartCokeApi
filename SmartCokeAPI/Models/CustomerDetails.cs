namespace SmartCokeAPI.Models
{
    public partial class CustomerDetails
    {
        public int Id { get; set; }
        public string CustCode { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Uname { get; set; }
        public string Password { get; set; }
        public string PhoneNum { get; set; }
        public string Email { get; set; }
        public string Dob { get; set; }
        public string DobDay { get; set; }
        public string DobMonth { get; set; }
        public string Membership { get; set; }
        public string Status { get; set; }
        public string Orders { get; set; }
        public string AltContactPersonName { get; set; }
        public string AltContactPersonNumber { get; set; }
        public string GhanaPost { get; set; }

        public string HowYouHeard { get; set; }

        public string ReferenceDetails { get;set;}
    }
}
