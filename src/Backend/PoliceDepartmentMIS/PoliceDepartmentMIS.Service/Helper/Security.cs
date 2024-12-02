namespace PoliceDepartmentMIS.Service.Helper
{
    public static class Security
    {
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool VerifyHash(string password, string hashValue)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashValue);
        }
    }
}
