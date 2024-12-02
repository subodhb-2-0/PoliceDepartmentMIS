namespace PoliceDepartmentMIS.Core.Domain.Base
{
    public interface IAuditable
    {
        public int InsertedBy { get; set; }
        public DateTime InsertedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
