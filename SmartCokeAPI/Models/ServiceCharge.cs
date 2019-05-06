namespace SmartCokeAPI.Models
{
    public partial class ServiceCharge
    {
        public int Id { get; set; }
        public string Definiton { get; set; }
        public string ServChrgAmt { get; set; }
        public string AddedBy { get; set; }
        public string AddedDate { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }

        public string MinimumCasesCount { get; set; }

        public string ChargePercentage { get; set; }
    }
}
