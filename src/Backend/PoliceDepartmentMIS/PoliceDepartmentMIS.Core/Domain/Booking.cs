using PoliceDepartmentMIS.Core.Domain.Base;

namespace PoliceDepartmentMIS.Core.Domain
{
    public class Booking : IDeletable, IAuditable
    {
        public int Id { get; set; }
        public int InmateId { get; set; }
        public string BookingLocation { get; set; }
        public string FacilityName { get; set; }
        public DateTime BookedDate { get; set; }
        public DateTime ReleasedDate { get; set; }
        public string Charges { get; set; }
        public string ReleasedInformation { get; set; }

        public bool IsDeleted { get; set; }
        public int InsertedBy { get; set; }
        public DateTime InsertedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
