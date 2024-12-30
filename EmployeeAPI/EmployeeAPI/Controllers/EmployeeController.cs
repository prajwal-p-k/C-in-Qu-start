using EmployeeAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeAPI.Data;
using EmployeeAPI.Model;
using EmployeeAPI.DTOs;
using Microsoft.EntityFrameworkCore;
using EmployeeAPI.Services;

namespace EmployeeAPI.Controllers
{
    //[Route("api/[controller]/[action]/{id?}/{email?}/{pwd?}")]
    [Route("api/[controller]/")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        ApplicationDBContext context;
        UserAuthentication user;
        public EmployeeController(ApplicationDBContext _context,UserAuthentication _auth)
        { 
            context=_context;
            user=_auth;
        }
        [HttpGet("GetEmployee")]
        public List<EmployeeDto> ListEmployee()
        {
            //return new List<Employee>();
            //return context.employees.Include("Department").ToList();
            List<EmployeeDto> employees = new List<EmployeeDto>();
            foreach (Employee emp in context.employees.Include("Departments").ToList())
            {
                employees.Add(new EmployeeDto { Id = emp.Id, Name = emp.Name, Address = emp.Address, Salary = emp.Salary, Mobile = emp.Mobile, DOB = emp.DOB, DOJ = emp.DOJ, Email = emp.Email, Password = emp.Password, Skillset = emp.Skillset, DepartmentId = emp.DepartmentId, DepartmentName = emp.Departments.DepartmentName });
            }
            return employees;
        }
        [HttpPost("New")]
        public void AddEmployee(EmployeeDto emp)
        {
            Employee empNew = new Employee();
            
            empNew.Name = emp.Name;
            empNew.Address = emp.Address;
            empNew.Email= emp.Email;
            empNew.DOJ = emp.DOJ;
            empNew.Salary = emp.Salary;
            empNew.Mobile = emp.Mobile;
            empNew.Skillset = emp.Skillset;
            empNew.DOB = emp.DOB;
            empNew.Password = emp.Password;
            empNew.DepartmentId = emp.DepartmentId;
            context.employees.Add(empNew);
            context.SaveChanges();
                
        }
        [HttpPut("Edit")] //put for updating
        public void Edit(EmployeeDto emp)
        {
            //context.employees.Find(emp.Id);
            Employee empdb=context.employees.Where(e=>e.Id==emp.Id).SingleOrDefault();
            empdb.Name= emp.Name;
            empdb.Address= emp.Address;
            empdb.Email= emp.Email;
            empdb.Skillset= emp.Skillset;
            empdb.DOB= emp.DOB;
            empdb.Password= emp.Password;
            empdb.DOJ= emp.DOJ;
            empdb.DepartmentId= emp.DepartmentId;
            empdb.Mobile= emp.Mobile;
            empdb.Salary = emp.Salary;
            
            context.SaveChanges();
        }
        [HttpDelete("Delete/{id}")]
        public void Delete(int id)
        {
            Employee empdb = context.employees.Where(e => e.Id == id).SingleOrDefault();
            if (empdb != null)
            {
                context.employees.Remove(empdb);
                context.SaveChanges();
            }
        }
        [HttpGet("Departments")]
        public List<DepartmentDto> ListDepartments()
        {
            List<DepartmentDto> list1 = new List<DepartmentDto>();

            foreach (Department d in context.departments.ToList())
            {
                list1.Add(new DepartmentDto { Id = d.Id, DepartmentName = d.DepartmentName });
            }
            return list1;
        }

        [HttpGet("Login/{email}/{pwd}")]
        public UserInfoDto Login(string email,string pwd)
        {
            //UserAuthentication auth = new UserAuthentication();
           return user.IsUserValid(email, pwd);
        }
        [HttpGet("GetEmployee/{id}")]
        public EmployeeDto GetEmployee(int id)
        {
            Employee emp = context.employees.Include("Departments").Where(e => e.Id == id).SingleOrDefault();
            return new EmployeeDto
            {
                Id = emp.Id,
                Name = emp.Name,
                Address = emp.Address,
                Salary = emp.Salary,
                Mobile = emp.Mobile,
                DOB = emp.DOB,
                DOJ = emp.DOJ,
                Email = emp.Email,
                Password = emp.Password,
                Skillset = emp.Skillset,
                DepartmentId = emp.DepartmentId,
                DepartmentName = emp.Departments.DepartmentName
            };

        }


    }
}
