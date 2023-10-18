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
        AirbnbDBEntities1 db = new AirbnbDBEntities1();
        public ActionResult Index(string name)
        {
            if (name == null)
            {
                return View(db.Rooms.ToList());


            }
            else
            {
                return View(db.Rooms.Where(s=>s.Name_Cate.Contains(name)).ToList());
            }
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
                return RedirectToAction("Index", "Product");

            }
            catch
            {
                return Content("Loi roi bro ");
            }
        }
        public ActionResult Detail(int id)
        {
            return View(db.Rooms.Where(s => s.ID_Cate == id).FirstOrDefault());

        }
        public ActionResult Edit(int id)
        {
            return View(db.Rooms.Where(s => s.ID_Cate == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int id,Room cate)
        {
            try
            {
                db.Entry(cate).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Sai roi bro, xoa di ma lam nguoi");
            }
        }
    }
}