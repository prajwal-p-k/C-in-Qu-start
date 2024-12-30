using EmployeeUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace EmployeeUI.Controllers
{
    public class EmployeeController : Controller
    {
        HttpClient client=new HttpClient();
        Uri baseAddress = new Uri("https://localhost:7006/api/Employee/");
      
        //public IActionResult Login(string ReturnUrl="/")
        //{
        //    UserInfo user = new UserInfo();
        //    user.ReturnUrl = ReturnUrl;
        //    return View(user);
        //}
        //[HttpPost]
        //public IActionResult Login(UserInfo user)
        //{
        //    string res = JsonConvert.SerializeObject(user);
        //    StringContent content1 = new StringContent(res,System.Text.Encoding.UTF8,"text/json");
        //    HttpResponseMessage msg = client.PostAsync(baseAddress + "Login",content1).Result;
        //    string content = msg.Content.ReadAsStringAsync().Result;
        //    UserInfo info=JsonConvert.DeserializeObject<UserInfo>(content)

        //    return View();
        //}
        //[Authorize]
        public IActionResult Index()
        {
            HttpResponseMessage msg=client.GetAsync(baseAddress+ "GetEmployee").Result;
            string content=msg.Content.ReadAsStringAsync().Result;
            List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(content);
            return View(employees);
        }
        public IActionResult Add()
        {
            HttpResponseMessage msg = client.GetAsync(baseAddress + "Departments").Result;

            string content = msg.Content.ReadAsStringAsync().Result;

            List<Departments> depts = JsonConvert.DeserializeObject<List<Departments>>(content);
            ViewBag.Departments = depts;
            return View();
        }
        [HttpPost]
        // public IActionResult Add(Employee emp)
        public async Task<IActionResult> Add(Employee emp)
        {
            emp.DepartmentName = "";
            string data = JsonConvert.SerializeObject(emp);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "text/json");
            await client.PostAsync(baseAddress + "New", content);

            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Delete(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync(baseAddress + "Delete/" + id);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            //ViewBag.ErrorMessage = "There was an issue deleting the employee.";
            return RedirectToAction("Index");
        }
        //edit
        public IActionResult Edit(int id)
        {
            HttpResponseMessage msg = client.GetAsync(baseAddress + "GetEmployee/" + id).Result;
            string content = msg.Content.ReadAsStringAsync().Result;
            Employee employee = JsonConvert.DeserializeObject<Employee>(content);
            HttpResponseMessage deptMsg = client.GetAsync(baseAddress + "Departments").Result;
            string deptContent = deptMsg.Content.ReadAsStringAsync().Result;
            List<Departments> departments = JsonConvert.DeserializeObject<List<Departments>>(deptContent);
            ViewBag.Departments = departments;
            return View(employee);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Employee emp)
        {
            emp.DepartmentName = "";
            string data = JsonConvert.SerializeObject(emp);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "text/json");
            await client.PutAsync(baseAddress + "Edit", content);
            return RedirectToAction("Index");
        }
        
    }
}
