namespace PoliceDepartmentMIS.Core.Dtos.Common
{
    public class FilterDto
    {
        public string SearchByColumn { get; set; }
        public string SearchValue { get; set; }
        public string OrderByColumn { get; set; }
        public string OrderBy { get; set; }
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
    }
}
