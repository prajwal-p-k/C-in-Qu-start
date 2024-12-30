using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PayRollMVCCore.Data;
using PayRollMVCCore.Models;
using PayRollMVCCore.Services;
using Microsoft.AspNetCore.Http;



namespace PayRollMVCCore.Controllers
{


    public class EmployeeController : Controller
    {

        ApplicationDBContext context;
        Authentication objAuth;

        public EmployeeController(ApplicationDBContext _context, Authentication _objAuth)
        {
            context = _context;
            objAuth = _objAuth;
        }
        //public IActionResult Index()
        //{
        //    List<Employee> emp = context.employees.Include("Department").ToList();
        //    return View(emp);
        //}

        public IActionResult Index(int page = 1, int pageSize = 5)
        {
            if (HttpContext.Session.GetInt32("isUserLoggedIn") != null && HttpContext.Session.GetInt32("isUserLoggedIn") == 1)
            {
                ViewBag.User = HttpContext.Session.GetString("user");
                ViewBag.IsLoggedIn = HttpContext.Session.GetInt32("isUserLoggedIn");
                var employees = context.employees.Include("Department");
                int totalRecords = employees.Count(); // Total number of records
                var paginatedEmployees = employees
                    .OrderBy(e => e.Id) // Order by ID or any other field
                    .Skip((page - 1) * pageSize) // Skip records for previous pages
                    .Take(pageSize) // Take only the records for the current page
                    .ToList();
                ViewBag.UserName = TempData["name"].ToString();
                TempData.Keep("name");
                ViewBag.CurrentPage = page; // Current page number
                ViewBag.TotalPages = (int)Math.Ceiling(totalRecords / (double)pageSize); // Total pages

                return View(paginatedEmployees);
            }
            return View("Login");
        }
        public IActionResult New()
        {
            if (HttpContext.Session.GetInt32("isUserLoggedIn") != null && HttpContext.Session.GetInt32("isUserLoggedIn") == 1)
            {
                ViewBag.User = HttpContext.Session.GetString("user");
                ViewBag.IsLoggedIn = HttpContext.Session.GetInt32("isUserLoggedIn");
                ViewBag.Departments = context.departments.ToList();
                return View("Register");
            }
            return View("Login");
        }
        [HttpPost]
        public IActionResult Save(Employee emp)
        {
            if (TempData["action"] != null && TempData["action"].ToString().Equals("edit"))
            {
                Employee empedit = context.employees.Where(e => e.Id == emp.Id).SingleOrDefault();
                empedit.Name = emp.Name;
                empedit.Email = emp.Email;
                empedit.Mobile = emp.Mobile;
                empedit.DOJ = emp.DOJ;
                empedit.DOB = emp.DOB;
                empedit.Password = emp.Password;
                empedit.Skillset = emp.Skillset;
                empedit.Salary = emp.Salary;
                empedit.DepartmentId = emp.DepartmentId;
                empedit.Address = emp.Address;
            }
            else
            {
                emp.Department = null;
                context.employees.Add(emp);
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        //[Route("Employee/change/{id?}/{name?}/{location?}")]
        public IActionResult Edit(int id)
        {
            if (HttpContext.Session.GetInt32("isUserLoggedIn") != null && HttpContext.Session.GetInt32("isUserLoggedIn") == 1)
            {
                Employee empedit = context.employees.Where(e => e.Id == id).SingleOrDefault();
                ViewBag.User = HttpContext.Session.GetString("user");
                ViewBag.IsLoggedIn = HttpContext.Session.GetInt32("isUserLoggedIn");
                TempData["action"] = "edit";
                ViewBag.Departments = context.departments.ToList();
                return View("Register", empedit);
            }
            return View("Login");
        }
        public IActionResult delete(int id)
        {
            if (HttpContext.Session.GetInt32("isUserLoggedIn") != null && HttpContext.Session.GetInt32("isUserLoggedIn") == 1)
            {
                Employee empedit = context.employees.Where(e => e.Id == id).SingleOrDefault();
                // TempData["name"] = "Santhosh";
                context.employees.Remove(empedit);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Login");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        //[Route("Employee/VaildateUser")]
        //[Route("Employee/AuthendicateUser")]
        public IActionResult Login(Employee emp)
        {
            if (objAuth.IsUserValid(emp.Email, emp.Password))
            {
                TempData["name"] = objAuth.UserName;
                TempData.Keep("name");
                //using Microsoaft.AspNetCore.Http
                HttpContext.Session.SetString("user", objAuth.UserName);
                HttpContext.Session.SetInt32("isUserLoggedIn",1);
                return RedirectToAction("Index");
            }
            ViewBag.Message = "Login failed";
            return View();
        }
    }
}
