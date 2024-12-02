namespace PoliceDepartmentMIS.Core.Dtos.Booking
{
    public class BookingResponseDto
    {
        public int Id { get; set; }
        public int InmateId { get; set; }
        public string InmateName { get; set; }
        public string BookingLocation { get; set; }
        public string FacilityName { get; set; }
        public DateTime BookedDate { get; set; }
        public DateTime? ReleasedDate { get; set; }
        public string Charges { get; set; }
        public string ReleasedInformation { get; set; }
    }
}
