using EmployeeAPI.Data;
using EmployeeAPI.DTOs;
using EmployeeAPI.Model;

namespace EmployeeAPI.Services
{
    public class UserAuthentication
    {
        ApplicationDBContext context;
        public UserAuthentication(ApplicationDBContext _context) { context = _context; }
        public UserInfoDto IsUserValid(string email,string pwd)
        {
            UserInfoDto info = new UserInfoDto();
            Employee emp=context.employees.Where(e=>e.Email==email && e.Password==pwd).SingleOrDefault();
            if (emp != null)
            {
                info.Id = emp.Id;
                info.Email = email;
                info.Name = emp.Name;
                info.IsLoggedIn = true;
            }
            else
            {
                info.IsLoggedIn= false;
                info.Message = "Authentication Failed";
            }
            return info;

        }
    }
}
