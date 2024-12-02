namespace PoliceDepartmentMIS.Core.Dtos.Inmates
{
    public class InmateRequestDto
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string CitizenshipNumber { get; set; }
    }
}
