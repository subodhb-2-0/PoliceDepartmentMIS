namespace PoliceDepartmentMIS.Service.Config
{
    public class JwtSettings
    {
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
        public string Secret { get; set; }
    }
}
