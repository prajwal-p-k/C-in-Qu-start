using FirstMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMVC.Controllers
{
    public class EmpoloyeeController : Controller
    {
        // GET: Empoloyee
        List<Employee> employees = new List<Employee>();
        public EmpoloyeeController() { 
            
            employees.Add(new Employee { Id = 1, Name = "prajwal", Department = "IT" });
            employees.Add(new Employee { Id = 2, Name = "manoj", Department = "sales" });
            employees.Add(new Employee { Id = 3, Name = "Bharath", Department = "admin" });


        }
        public ActionResult Index()
        {
            return View(employees);
        }
        //public ActionResult List()
        //{
        //    return View(employees);
        //}
    }
}