    using BLL;
using Dekorasyon.WebApp.Filters;
using Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Entities;
using Dekorasyon.WebApp.Models;

namespace Dekorasyon.WebApp.YonetimControllers
{
    [Auth]
    [Exc]
    public class YonetimContactController : Controller
    {
        ContactManager contactManager = new ContactManager();
        AracistekManager aracistekManager = new AracistekManager();
        SSSManager ssmanager = new SSSManager();
        // GET: Contact
        [Auth]
        public ActionResult Index()
        {
            return View(contactManager.List());
        }
        [Auth]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = contactManager.Find(x => x.Id == id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }
        public ActionResult SSSList()
        {
            return View(ssmanager.List());
        }
        public ActionResult SSSCreate(SSS ss)
        {
            ssmanager.Insert(ss);
            return View();
        }
        [Auth]
        public ActionResult AracistekIndex()
        {
            return View(aracistekManager.List());
        }
        [Auth]
        public ActionResult AracistekDetail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aracistek aracistek = aracistekManager.Find(x => x.Id == id);
            if (aracistek == null)
            {
                return HttpNotFound();
            }
            return View(aracistek);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Contact contact = contactManager.Find(x => x.Id == id.Value);

            if (contact == null)
            {
                return HttpNotFound();
            }

            return View(contact);
        }
        [Auth]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact contact = contactManager.Find(x => x.Id == id);
            contactManager.Delete(contact);

            CacheHelper.RemoveMessageFromCache();


            return RedirectToAction("Index");
        }
        public ActionResult DeleteArac(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Aracistek aracistek = aracistekManager.Find(x => x.Id == id.Value);

            if (aracistek == null)
            {
                return HttpNotFound();
            }

            return View(aracistek);
        }
        [Auth]
        [HttpPost, ActionName("DeleteArac")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedi(int id)
        {
            Aracistek aracistek = aracistekManager.Find(x => x.Id == id);
            aracistekManager.Delete(aracistek);

            CacheHelper.RemoveMessageFromCache();


            return RedirectToAction("AracistekIndex");
        }
    }
}