using AirBnB_Clone_project.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirBnB_Clone_project.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        AirbnbDBEntities2 db = new AirbnbDBEntities2();
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
            Rooms cate = new Rooms();
            return View(cate);
        }
        //[HttpPost]
        //public ActionResult Create(Rooms cate)
        //{
        //    try
        //    {
        //        db.Rooms.Add(cate);
        //        db.SaveChanges();
        //        return RedirectToAction("Control");

        //    }
        //    catch
        //    {
        //        return Content("Loi roi bro ");
        //    }
        //}
        [HttpPost]
        public ActionResult Create(Rooms pro)
        {
            try
            {
                if (pro.UploadImage != null)
                {
                    string filename = Path.GetFileNameWithoutExtension(pro.UploadImage.FileName);
                    string extent = Path.GetExtension(pro.UploadImage.FileName);
                    filename += extent;
                    pro.Images_Cate = "~/Content/image/" + filename;
                    pro.UploadImage.SaveAs(Path.Combine(Server.MapPath("~/Content/image/"), filename));
                }
                db.Rooms.Add(pro);
                db.SaveChanges();
                return RedirectToAction("Index","Product");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View(db.Rooms.Where(s => s.Id_Room == id).FirstOrDefault());
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
        public ActionResult Edit(int id,Rooms cate)
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
        public ActionResult Control()
        {
            return View(db.Rooms.ToList());
        }
    }
}