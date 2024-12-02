namespace PoliceDepartmentMIS.Core.Dtos.Booking
{
    public class BookingGetAllResponseDto
    {
        public int Id { get; set; }
        public int InmateId { get; set; }
        public string InmateName { get; set; }
        public string BookingLocation { get; set; }
        public string FacilityName { get; set; }
        public string BookedDate { get; set; }
        public string ReleasedDate { get; set; }
        public string Charges { get; set; }
        public string ReleasedInformation { get; set; }
    }
}
