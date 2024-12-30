using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment.Controllers
{

    public class HomeController : Controller
    {
        MyShopEntities context = new MyShopEntities();
        public ActionResult Index()
        {
            // Fetch all categories and pass them to the view using ViewBag
            var categories = context.CategoryLists.ToList();
            ViewBag.CategoryList  = new SelectList(categories, "catid", "Category"); // SelectList simplifies dropdown generation.
            return View();
        }

        [HttpPost]
        public ActionResult List(int catid)
        {
            // Fetch products based on the selected category ID
            var listOfProducts = context.ProductMasters.Where(p => p.Catid == catid).ToList();
            ViewBag.Products = listOfProducts;

            // Fetch categories again for the dropdown
            var categories = context.CategoryLists.ToList();
            ViewBag.CategoryList = new SelectList(categories, "catid", "Category", catid);

            return View("Index");
        }





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