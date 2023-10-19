using AirBnB_Clone_project.Models;
using Antlr.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirBnB_Clone_project.Controllers
{
    public class ProductController : Controller
    {
        // GET
        AirbnbDBEntities2 db = new AirbnbDBEntities2();

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
            Rooms room = new Rooms();
            return View(room);

        }
        public ActionResult Detail(int id)
        {
            return View(db.Rooms.Where(s => s.Id_Room == id).FirstOrDefault());
        }
        //[HttpPost]
      
 
        //public ActionResult Create(Rooms room)
        //{
        //    try
        //    {
        //        db.Rooms.Add(room);

        //        db.SaveChanges();
        //        return RedirectToAction("Control","Product");
        //    }
        //    catch
        //    {
        //        return Content("Sai roi bro bo di ma lam ng");
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
                    pro.Images_Room = "~/Content/image/" + filename;
                    pro.UploadImage.SaveAs(Path.Combine(Server.MapPath("~/Content/image/"), filename));
                }
                db.Rooms.Add(pro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            return View(db.Rooms.Where(s => s.Id_Room == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int id, Rooms room)
        {
            try
            {
                if (room.UploadImage != null)
                {
                    string filename = Path.GetFileNameWithoutExtension(room.UploadImage.FileName);
                    string extent = Path.GetExtension(room.UploadImage.FileName);
                    filename += extent;
                    room.Images_Room = "~/Content/image/" + filename;
                    room.UploadImage.SaveAs(Path.Combine(Server.MapPath("~/Content/image/"), filename));
                }
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
        public ActionResult Delete(int id, Rooms room)
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
            Rooms catels = new Rooms();
            catels.ListCate = db.Rooms.ToList<Rooms>();
            return PartialView(catels);

        }
    }
}