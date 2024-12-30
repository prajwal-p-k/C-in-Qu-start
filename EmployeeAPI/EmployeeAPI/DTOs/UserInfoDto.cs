namespace EmployeeAPI.DTOs
{
    public class UserInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public bool IsLoggedIn { get; set; }
        //public string Password { get; set; }
    }
}
