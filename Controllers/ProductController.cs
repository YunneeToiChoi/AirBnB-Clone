using AirBnB_Clone_project.Models;
using Antlr.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirBnB_Clone_project.Controllers
{
    public class ProductController : Controller
    {
        // GET
        AirbnbDBEntities1 db = new AirbnbDBEntities1();

        public int? ID_Cate { get; private set; }

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
        public ActionResult Detail(int id)
        {
            return View(db.Rooms.Where(s => s.Id_Room == id).FirstOrDefault());
        }
        [HttpPost]
      
 
        public ActionResult Create(Room room)
        {
            try
            {
                db.Rooms.Add(room);

                db.SaveChanges();
                return RedirectToAction("Control","Product");
            }
            catch
            {
                return Content("Sai roi bro bo di ma lam ng");
            }
        }
        public ActionResult Edit(int id)
        {
            return View(db.Rooms.Where(s => s.Id_Room == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int id, Room room)
        {
            try
            {
                db.Entry(room).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Sai roi bro, xoa di ma lam nguoi");
            }
        }
        public ActionResult Delete(int id)
        {
            return View(db.Rooms.Where(s => s.Id_Room == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(int id, Room room)
        {
            try
            {   
                room = db.Rooms.Where(s=>s.Id_Room == id).FirstOrDefault();
                db.Rooms.Remove(room);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Sai roi bro, xoa di ma lam nguoi");
            }
        }
        public ActionResult Control()
        {
            return View(db.Rooms.ToList());
        }
        public ActionResult SelectCate()
        {
            Room catels = new Room();
            catels.ListCate = db.Rooms.ToList<Room>();
            return PartialView(catels);

        }
    }
}