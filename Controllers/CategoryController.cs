using AirBnB_Clone_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace AirBnB_Clone_project.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        AirbnbEntities db = new AirbnbEntities();
        public ActionResult Category_Index(string name)
        {
            var item = db.Categories.Where(s => s.Name_Cate.Contains(name)).ToList();
            if (name == null)
            {
                return PartialView("Category_Index", db.Categories.ToList());
            }
            else
            {
                return PartialView("Category_Index", db.Categories.Where(s => s.Name_Cate.Contains(name)).ToList());
            }
        }
<<<<<<< Updated upstream
<<<<<<< Updated upstream
       
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
=======
        //public ActionResult Delete(int id)
        //{
        //    return View(db.Rooms.Where(s => s.Id_Room == id).FirstOrDefault());
        //}
        //public ActionResult Detail(int id)
        //{
        //    return View(db.Rooms.Where(s => s.ID_Cate == id).FirstOrDefault());

=======
        //public ActionResult Delete(int id)
        //{
        //    return View(db.Rooms.Where(s => s.Id_Room == id).FirstOrDefault());
        //}
        //public ActionResult Detail(int id)
        //{
        //    return View(db.Rooms.Where(s => s.ID_Cate == id).FirstOrDefault());

>>>>>>> Stashed changes
        //}
        //public ActionResult Edit(int id)
        //{
        //    return View(db.Rooms.Where(s => s.ID_Cate == id).FirstOrDefault());
        //}
        //[HttpPost]
        //public ActionResult Edit(int id,Room cate)
        //{
        //    try
        //    {
        //        db.Entry(cate).State = System.Data.Entity.EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return Content("Sai roi bro, xoa di ma lam nguoi");
        //    }
        //}
        //public ActionResult Control()
        //{
        //    return View(db.Rooms.ToList());
        //}
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
    }
}
