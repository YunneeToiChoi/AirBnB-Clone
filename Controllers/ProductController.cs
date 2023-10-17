using AirBnB_Clone_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirBnB_Clone_project.Controllers
{
    public class ProductController : Controller
    {
        // GET
        AirbnbEntities db = new AirbnbEntities();
        public ActionResult Index()
        {
            return View(db.Rooms.ToList());
        }
        public ActionResult Bear()
        {
            return View();
        }
        public ActionResult Loading()
        {
            return View();
        }
        public ActionResult Create()
        {
            Room room = new Room();
            return View(room);

        }
        [HttpPost]
        public ActionResult Create(Room room)
        {
            
                db.Rooms.Add(room);
                db.SaveChanges();
                return RedirectToAction("Index");
            

        }

    }
}