using AirBnB_Clone_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirBnB_Clone_project.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        AirbnbEntities db = new AirbnbEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            Room cate = new Room();
            return View(cate);
        }
        [HttpPost]
        public ActionResult Create(Room cate)
        {
            try
            {
                db.Rooms.Add(cate);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            catch
            {
                return Content("Loi roi bro ");
            }
        }
    }
}