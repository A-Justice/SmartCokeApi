namespace SmartCokeAPI.Models
{
    public class CustomerAddress
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string Address { get; set; }

        public string RegionId { get; set; }
        public string RegionName { get; set; }

        public string DistrictId { get; set; }

        public string DistrictName { get; set; }


        public string AreaId { get; set; }

        public string AreaName { get; set; }
    }
}
