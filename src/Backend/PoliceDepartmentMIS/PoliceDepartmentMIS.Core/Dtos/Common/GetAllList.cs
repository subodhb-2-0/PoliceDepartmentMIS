namespace PoliceDepartmentMIS.Core.Dtos.Common
{
    public class GetAllList<T>
    {
        public List<T> DataList { get; set; }
        public int TotalCount { get; set; }
    }
}
