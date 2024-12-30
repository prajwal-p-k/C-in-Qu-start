using DatabaseMVC.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatabaseMVC.Controllers
{

  
    public class HomeController : Controller
    {
        schoolEntities context = new schoolEntities();
        //public ActionResult Index()
        //{
        //    List<Employee> emp = Context.Employee.ToList();
        //}
        public ActionResult Index()
        {
            if (Convert.ToBoolean(Session["isUserLoggedIn"]) && Session["userName"] != null)
            {
                List<Mark> emp = context.Marks.ToList();
                return View(emp);
            }
            return RedirectToAction("Login");
        }
        public ActionResult Add()
        {
            if (Convert.ToBoolean(Session["isUserLoggedIn"]) && Session["userName"] != null)
            {
                List<Subject> sub = context.Subjects.ToList();
                ViewBag.Subject = sub;
                return View();
            }
            return RedirectToAction("Login");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(AppUser user) {
            var loggedInUser =context.AppUsers.Where(u=>u.Email==user.Email && u.Password==user.Password).SingleOrDefault();
            if (loggedInUser != null)
            {
                Session["isUserLoggedIn"] = true;
                Session["userName"] = loggedInUser.Name;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Authentication is faild";
                return View(loggedInUser);
            }
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }
        [HttpPost]
        public ActionResult Save(Mark m)
        {
            if (Convert.ToInt32(TempData["action"]) == 2)
            {
                Mark mp=context.Marks.Where(emp=>emp.Stid==m.Stid).Single();
                mp.Stid = m.Stid;
                mp.Subject.subid = m.Subid;
                mp.Score = m.Score;
            }
            else
            {
                context.Marks.Add(m);
            }
            
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int Stid)
        {
            List<Subject> sub = context.Subjects.ToList();
            ViewBag.Subject = sub;

            Mark m = context.Marks.Where(e => e.Stid == Stid).Single();
            TempData["action"] = 2;
            return View("Add",m);
        }
        public ActionResult Delete(int Stid)
        {
            Mark m = context.Marks.Where(e => e.Stid == Stid).Single();
            context.Marks.Remove(m);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        //[HttpPost]
        //public ActionResult Add(Mark m)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Check if Subid exists in Subjects
        //        var subjectExists = context.Subjects.Any(s => s.subid == m.Subid);
        //        if (!subjectExists)
        //        {
        //            ModelState.AddModelError("Subid", "Invalid Subject ID.");
        //            List<Subject> sub = context.Subjects.ToList();
        //            ViewBag.Subject = sub;
        //            return View(m);
        //        }

        //        context.Marks.Add(m);
        //        context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    // Repopulate ViewBag.Subject on validation failure
        //    List<Subject> subList = context.Subjects.ToList();
        //    ViewBag.Subject = subList;
        //    return View(m);
        //}


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}