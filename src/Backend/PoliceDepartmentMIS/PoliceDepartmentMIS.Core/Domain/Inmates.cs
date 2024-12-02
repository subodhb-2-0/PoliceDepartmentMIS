using PoliceDepartmentMIS.Core.Domain.Base;

namespace PoliceDepartmentMIS.Core.Domain
{
    public class Inmates : IDeletable, IAuditable
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string CitizenshipNumber { get; set; }

        public bool IsDeleted { get; set; }
        public int InsertedBy { get; set; }
        public DateTime InsertedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
