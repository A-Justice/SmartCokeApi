namespace SmartCokeAPI.Models
{
    public partial class Distributors
    {
        public int Id { get; set; }
        public string DistrictId { get; set; }
        public string DistribId { get; set; }
        public string DistrictName { get; set; }
        public string Township { get; set; }
        public string Outlet { get; set; }
        public string OtcontactPerson { get; set; }
        public string OtcontactNumber { get; set; }
        public string Otemail { get; set; }
        public string Rssname { get; set; }
        public string Rssnumber { get; set; }
        public string Rssemail { get; set; }
        public string Rsmname { get; set; }
        public string Rsmnumber { get; set; }
        public string Rsmemail { get; set; }
        public string Status { get; set; }
        public string AddedBy { get; set; }
        public string AddedDate { get; set; }
        public string EditedBy { get; set; }
        public string EditedDate { get; set; }
        public string RegionId { get; set; }

        //address.userId = getString(getColumnIndexOrThrow(COLUMN_NAME_USERID))
    }
}
