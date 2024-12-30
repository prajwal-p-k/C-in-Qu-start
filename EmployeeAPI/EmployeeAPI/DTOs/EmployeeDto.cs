namespace EmployeeAPI.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public long Mobile { get; set; }
        public string Password { get; set; }
        public string DOB { get; set; }
        public string DOJ { get; set; }

        public decimal Salary { get; set; }
        public string Skillset { get; set; }

        
        public string Address { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
