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
    public class boktamuController : Controller
    {
        guestbookEntities db = new guestbookEntities();
        // GET: boktamu
        public ActionResult Index(int id)
        {
            var bktmu = (from b in db.bukutamu.Include("bukutamu")
                         where b.id == id
                         select b).SingleOrDefault();
                
            return View(bktmu);
        }

        // GET: boktamu/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Bukutamu(string cari)
        {
            var bkTmu = from c in db.bukutamu select c;
            if (!String.IsNullOrEmpty(cari))
            {
                bkTmu = bkTmu.Where(c => c.nama.Contains(cari) || c.nama.Contains(cari));
            }
            return View(bkTmu.ToList());
        }

        // GET: boktamu/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: boktamu/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: boktamu/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: boktamu/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: boktamu/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: boktamu/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
