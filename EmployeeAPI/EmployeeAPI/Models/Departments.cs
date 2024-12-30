namespace EmployeeAPI.Model
{
    public class Department
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }

        public virtual List<Employee> Employees { set; get; }
    }
}
