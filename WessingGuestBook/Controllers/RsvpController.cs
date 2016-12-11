using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.IO;
using PagedList;
using WessingGuestBook.Models;

namespace WessingGuestBook.Controllers
{
    public class RsvpController : Controller
    {
        private guestbookEntities db = new guestbookEntities();
        // GET: Rsvp
        public ActionResult Index(int? page)
        {
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            var gstBook = db.bukutamu.OrderBy(b => b.nama);
            return View(gstBook.ToPagedList(pageNumber,pageSize));
        }

        // GET: Rsvp/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Rsvp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rsvp/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(bukutamu bktamu, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                string pic = Guid.NewGuid().ToString().Substring(0, 6) +
                    Path.GetFileName(file.FileName);
                string path = Path.Combine(Server.MapPath("~/Images"), pic);
                file.SaveAs(path);

                bktamu.pict = pic;
                db.bukutamu.Add(bktamu);
                db.SaveChanges();

                ViewBag.Success = "Buku Tamu Berhasil Ditambahkan";
                return RedirectToAction("Index");
            }
           return View(bktamu);
        }

        // GET: Rsvp/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            bukutamu bokTamu = db.bukutamu.Find(id);
                if (bokTamu == null)
            {
                return HttpNotFound();
            }
            return View(bokTamu);
        }

        // POST: Rsvp/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(bukutamu bokTamu, HttpPostedFileBase file)
        {
            string imgFolder = Server.MapPath("~/Images");
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    //hapus file pict lama dulu
                    string oldpict = Path.Combine(imgFolder, bokTamu.pict !=
                        null ? bokTamu.pict : "");
                    if (System.IO.File.Exists(oldpict))
                        System.IO.File.Delete(oldpict);

                    //tambah file pict baru
                    string pic = Guid.NewGuid().ToString().Substring(0, 6) +
                        Path.GetFileName(file.FileName);
                    string path = Path.Combine(imgFolder, pic);
                    file.SaveAs(path);
                    bokTamu.pict = pic;
                }
                db.Entry(bokTamu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(bokTamu);
        }
           

        // GET: Rsvp/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bukutamu bokTamu = db.bukutamu.Find(id);
            if (bokTamu == null)
            {
                return HttpNotFound();
            }
            return View(bokTamu);
        }

        // POST: Rsvp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            bukutamu bokTamu = db.bukutamu.Find(id);
            db.bukutamu.Remove(bokTamu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
